using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Services.Handlers
{
    public class AuthenticationServiceDefault : IAuthenticationService
    //TODO interface
    {
        private readonly IConfiguration config;
        private readonly IUsuarioRepository usuarioRepository;

        public AuthenticationServiceDefault(IConfiguration config, IUsuarioRepository usuarioRepository)
        {
            this.config = config;
            this.usuarioRepository = usuarioRepository;
        }


        public async Task<SignInResponseModel> SignInAsync(SignInRequestModel model)
        {
            if ((await usuarioRepository.FindByUsernameAsync(model.Username)) is Usuarios usuario
                && PasswordHasher.VerifyHashedPassword(usuario.SenhaHash, model.Password))
            {

                return new SignInResponseModel
                {
                    Username = usuario.Usuario,
                    Token = CreateJwtToken(usuario)

                    //RefreshToken
                    //RefreshTokenExpiration
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
    }
}