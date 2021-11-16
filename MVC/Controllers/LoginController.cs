using BogusService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        private Service<User> _service;

        public LoginController(Service<User> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var user = _service.Entities.Skip(2).First();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password, string returnUrl)
        {
            var user = _service.Entities.Where(x => x.Username == username).SingleOrDefault(x => x.Password == password);

            if(user == null)
            {
                ModelState.AddModelError(nameof(username), "Invalid credentials");
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            claims.AddRange(user.Role.ToString().Split(',').Select(x => new Claim(ClaimTypes.Role, x.Trim())));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));

            if (!Url.IsLocalUrl(returnUrl))
                returnUrl = Url.Content("/");
            return Redirect(returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
