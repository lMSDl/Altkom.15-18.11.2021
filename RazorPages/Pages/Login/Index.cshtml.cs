using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BogusService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace RazorPages.Pages.Login
{
    public class IndexModel : PageModel
    {
        private string returnUrl;

        public Service<User> Service { get; }

        public IndexModel(Service<User> service)
        {
            Service = service;
        }

        [BindProperty]
        public string ResutnUrl { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

   
        public async Task<IActionResult> OnPostAsync()
        {
            var user = Service.Entities.Where(x => x.Username == Username).SingleOrDefault(x => x.Password == Password);

            if (user == null)
            {
                ModelState.AddModelError(nameof(Username), "Invalid credentials");
                return Page();
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


    }
}
