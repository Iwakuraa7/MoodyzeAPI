using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodyzeAPI.Dtos.AppUser
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}