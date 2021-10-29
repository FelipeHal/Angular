using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartSchool.Core;
using SmartSchool.Core.BusinessEntities;
using SmartSchool.Core.Helper.Identity;
using SmartSchool.Core.Repositories;
using SmartSchool.WebAPI.Helper.Exceptions;
using SmartSchool.WebAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Services.Handlers
{
    public class AuthenticationServiceDefault : IAuthenticationService
    //TODO interface
    {
        private readonly IConfiguration config;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IUsuarioRefreshTokensRepository refreshTokensRepository;
        private readonly DataContext context;

        public AuthenticationServiceDefault(IConfiguration config, IUsuarioRepository usuarioRepository, IUsuarioRefreshTokensRepository refreshTokensRepository, DataContext context)
        {
            this.config = config;
            this.usuarioRepository = usuarioRepository;
            this.refreshTokensRepository = refreshTokensRepository;
            this.context = context;
        }


        public async Task<SignInResponseModel> SignInAsync(SignInRequestModel model)
        {
            if ((await usuarioRepository.FindByUsernameAsync(model.Username)) is Usuarios usuario
                && PasswordHasher.VerifyHashedPassword(usuario.SenhaHash, model.Password))
            {
                var refreshToken = CreateRefreshToken(usuario);

                await refreshTokensRepository.InsertAsync(refreshToken);
                await context.SaveChangesAsync();

                return new SignInResponseModel
                {
                    Username = usuario.Usuario,

                    Token = CreateJwtToken(usuario),

                    RefreshToken = refreshToken.Token
                };
            }
            throw new InvalidAuthenticationException();
        }



        private string CreateJwtToken(Usuarios usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor()
            {
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]))
                    , SecurityAlgorithms.HmacSha256
                ),

                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim("uid", usuario.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, usuario.Usuario)
                    }
                ),

                Issuer = config["JWT:Issuer"],
                Audience = config["JWT:Audience"],

                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(config["JWT:DurationInMinutes"]))

            });

            return tokenHandler.WriteToken(token);
        }

        private UsuarioRefreshTokens CreateRefreshToken(Usuarios usuario)
        {
            var data = new byte[32];
            
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(data);

            return context.CreateProxy<UsuarioRefreshTokens>(x =>
            {
                x.UsuarioID = usuario.Id;
                x.Usuario = usuario;
                x.Token = Convert.ToBase64String(data);
                x.Expiration = DateTime.UtcNow.AddDays(Convert.ToInt32(config["JWT:RefreshTokenExpiration"]));
                x.Created = DateTime.UtcNow;
            });
        }
    }
}