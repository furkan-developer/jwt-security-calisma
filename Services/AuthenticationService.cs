using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT_Security.Entities;
using JWT_Security.Models;
using JWT_Security.Services.ResultStructure;
using Microsoft.AspNetCore.Identity;

namespace JWT_Security.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResultStructure.IResult> Registration(UserRegistrationModel userModel)
        {
            // mapping
            AppUser user = new()
            {
                LastName = userModel.LastName,
                FirstName = userModel.FirstName,
                UserName = userModel.UserName,
                Email = userModel.Email
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (!result.Succeeded)
            {
                var stringBuilder = new StringBuilder();
                foreach (var item in result.Errors)
                {
                    stringBuilder.Append(item.Description);
                }

                return new ErrorResult(stringBuilder.ToString());
            }

            await _userManager.AddToRoleAsync(user, "Visitor");

            return new SuccessResult("Kayıt işlemi başarılı.");
        }

        public async Task<ResultStructure.IResult> Validate(UserLoginModel userModel)
        {
            var user = await _userManager.FindByEmailAsync(userModel.Email);
            
            var result = (user != null && await _userManager.CheckPasswordAsync(user, userModel.Password));
            if (!result)
            {
                return new ErrorResult("Authenticate işlemi başarısız. E-mail veya şifre yanlış");
            }

            return new SuccessResult();
        }
    }
}