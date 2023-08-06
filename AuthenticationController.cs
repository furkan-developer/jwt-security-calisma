using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT_Security.Entities;
using JWT_Security.Models;
using JWT_Security.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}