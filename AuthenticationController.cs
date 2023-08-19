using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT_Security.Entities;
using JWT_Security.Models;
using JWT_Security.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWT_Security
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationModel userModel)
        {
            var result = await _authenticationService.Registration(userModel);
            if (!result.Process)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userModel)
        {
            var result = await _authenticationService.Validate(userModel);
            if (!result.Process)
                return Unauthorized(result);

            // Create token
            string jwtToken = _authenticationService.CreateJwtToken();

            return Ok(new
            {
                AccesToken = jwtToken
            });
        }
    }
}