using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using MoodyzeAPI.Models;

namespace MoodyzeAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}