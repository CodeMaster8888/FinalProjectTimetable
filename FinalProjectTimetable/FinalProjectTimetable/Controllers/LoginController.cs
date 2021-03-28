using Data;
using FinalProjectTimetable.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services;
using Services.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTimetable.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ILoginManager _loginManager;
        private readonly AppSettingsRoot _appSettingsRoot;

        public LoginController(ILoginManager loginManager, AppSettingsRoot appSettingsRoot)
        {
            _loginManager = loginManager ?? throw new ArgumentNullException(nameof(loginManager));
            _appSettingsRoot = appSettingsRoot ?? throw new ArgumentNullException(nameof(appSettingsRoot));
        }

        public bool GetLogin(string username, string password)
        {
            return false;
        }

        [AllowAnonymous]
        [HttpPost("/authenticate")]
        public IActionResult Authenticate(AuthenticateLogin authenticateLogin)
        {
            var user = _loginManager.Authenticate(authenticateLogin.Username, authenticateLogin.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var user = new User { Username = model.Username };

            try
            {
                _loginManager.Create(user, model.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
