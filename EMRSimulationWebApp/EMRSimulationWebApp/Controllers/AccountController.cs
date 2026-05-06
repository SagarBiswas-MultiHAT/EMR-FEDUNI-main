using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace EMRSimulationWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult EmrLogin()
        {
/*
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
*/
            return View();
        }

        public IActionResult Login(string login)
        {
            ViewData["login"] = login;
            return View();
        }

        public IActionResult StudentLogin(string login)
        {
            ViewData["login"] = login;
            return View();
        }

        public IActionResult SupervisorLogin()
        {
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            var userRole = User.FindFirst("Role")?.Value;
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync();

            var userRoles = User.FindFirst("Role")?.Value;
            return RedirectToAction("EmrLogin", "Account");
        }
    }
}
