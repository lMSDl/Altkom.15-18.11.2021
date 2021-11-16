using BogusService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class UsersController : Controller
    {
        private Service<User> _service;
        public UsersController(Service<User> service)
        {
            _service = service;
        }

        [Authorize(Roles = nameof(Roles.Read))]
        public IActionResult Index()
        {
            //var users = string.Join("\n", _service.Entities.Select(x => x.ToString()).ToList());

            return View(_service.Entities);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = nameof(Roles.Read))]
        public IActionResult Search(string username, Roles? roles)
        {
            var users = (IEnumerable<User>)_service.Entities;
            if (!string.IsNullOrWhiteSpace(username))
                users = users.Where(x => x.Username.Contains(username));
            if (roles != null)
                users = users.Where(x => x.Role.HasFlag(roles.Value));

            return View(nameof(Index), users.ToList());
        }

        [Authorize(Roles = nameof(Roles.Create))]
        public IActionResult Add()
        {
            return View(new User());
        }

        [HttpPost]
        [Authorize(Roles = nameof(Roles.Create))]
        public IActionResult Add(User user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }

            if(_service.Entities.Any(x => x.Username == user.Username))
            {
                ModelState.AddModelError(nameof(user.Username), "Username already exists");
                return View(user);
            }

            user.Id = _service.Entities.Max(x => x.Id) + 1;
            _service.Entities.Add(user);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = nameof(Roles.Update))]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var item = _service.Entities.SingleOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Roles.Update))]
        public IActionResult Edit(int id, [Bind("Password", "Role")]User user /*string username, string password, Roles roles*/)
        {
            if(!ModelState.IsValid)
            {
                user.Id = id;
                return View(user);
            }

            var item = _service.Entities.Single(x => x.Id == id);
            if(!string.IsNullOrWhiteSpace(user.Password))
                item.Password = user.Password;
            item.Role = user.Role;

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = nameof(Roles.Delete))]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var item = _service.Entities.SingleOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = nameof(Roles.Delete))]
        public IActionResult DeleteUser(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            _service.Entities.Remove(_service.Entities.Single(x => x.Id == id));

            return RedirectToAction(nameof(Index));
        }
    }
}
