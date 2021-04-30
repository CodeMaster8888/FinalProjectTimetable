using Data;
using FinalProjectTimetable.FrontEndData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Configuration;
using System;

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
        public User Authenticate(AuthenticateLogin authenticateLogin)
        {
            var user = _loginManager.Authenticate(authenticateLogin.Username, authenticateLogin.Password);

            if (user == null)
                return null;

            return user;
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
