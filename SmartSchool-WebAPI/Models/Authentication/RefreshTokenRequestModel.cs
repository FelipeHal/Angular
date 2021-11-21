using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Models.Authentication
{
    public class RefreshTokenRequestModel
    {
        public string Username { get; set; }
        public string RefreshToken { get; set; }
    }
}
