using BogusService;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        private Service<User> _service;
        public UsersController(Service<User> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            //var users = string.Join("\n", _service.Entities.Select(x => x.ToString()).ToList());

            return View(_service.Entities);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Search(string username, Roles? roles)
        {
            var users = (IEnumerable<User>)_service.Entities;
            if (!string.IsNullOrWhiteSpace(username))
                users = users.Where(x => x.Username.Contains(username));
            if (roles != null)
                users = users.Where(x => x.Role.HasFlag(roles.Value));

            return View(nameof(Index), users.ToList());
        }
    }
}
