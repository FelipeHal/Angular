using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Helper.Exceptions;
using SmartSchool.WebAPI.Models.Authentication;
using SmartSchool.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }


        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInRequestModel model)
        {
            try
            {
                return Ok(await authenticationService.SignInAsync(model));
            }
            catch (InvalidAuthenticationException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
