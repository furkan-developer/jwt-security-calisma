using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT_Security.Models;

namespace JWT_Security.Services
{
    public interface IAuthenticationService
    {
        Task<ResultStructure.IResult> Registration(UserRegistrationModel userModel);
        Task<ResultStructure.IResult> Validate(UserLoginModel userModel);
        string CreateJwtToken();
    }
}