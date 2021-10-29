using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Models.Authentication
{
    public class SignInResponseModel
    {
        public string Username { get; set; }

        public string Token { get; set; }
    }
}