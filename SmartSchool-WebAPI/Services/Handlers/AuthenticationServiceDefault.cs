using SmartSchool.Core.BusinessEntities;
using SmartSchool.Core.Helper.Identity;
using SmartSchool.Core.Repositories;
using SmartSchool.WebAPI.Helper.Exceptions;
using SmartSchool.WebAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Services.Handlers
{
    public class AuthenticationServiceDefault : IAuthenticationService
    //TODO interface
    {
        private readonly IUsuarioRepository usuarioRepository;

        public AuthenticationServiceDefault(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }


        public async Task<bool> SignInAsync(SignInRequestModel model)
        {
            if ((await usuarioRepository.FindByUsernameAsync(model.Username)) is Usuarios usuario
                && PasswordHasher.VerifyHashedPassword(usuario.SenhaHash, model.Password))
            {
                return true;
            }
            throw new InvalidAuthenticationException();
        }
    }
}