using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _jwtAuth;

        public AuthenticationController(IAuthentication jwtAuth)
        {
            _jwtAuth = jwtAuth;
        }


        //// POST api/<LoginController>
        //[AllowAnonymous]
        //[HttpPost("authentication")]
        //public IActionResult Authentication([FromBody] UserCredential userCredential)
        //{
        //    var token = _jwtAuth.Authentication(userCredential.Username, userCredential.Password);
        //    if (token == null)
        //        return Unauthorized();
        //    return Ok(token);
        //}
    }
}
