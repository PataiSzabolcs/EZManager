using BusinessManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManager.Controllers
{
    [Route("")]
    [Route("login")]
    public class LoginController : Controller
    {
        private LoginService loginService;

        public LoginController(LoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpGet("")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult LoginCheck(string username, string password)
        {
            if (username.Equals("Admin") && loginService.IsAuthorized(username, password))
            {
                return Redirect("/admin");
            }
            if (loginService.IsAuthorized(username, password))
            {
                return Redirect($"/user/setuser/{loginService.GetUserId(username)}");
            }
            ViewBag.Message = "Wrong credentials!";
            return View("LoginPage", ViewBag.Message);
        }
    }
}
