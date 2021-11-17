using BogusService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Pages.Users
{
    public class AddOrEdit : PageModel
    {
        public Service<User> Service { get; }
        [BindProperty]
        public User Entity { get; set; }

        public AddOrEdit(Service<User> service)
        {
            Service = service;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public void OnGet()
        {
            if (!Service.Entities.Any(x => x.Id == Id))
                return;
            Entity = Service.Entities.Single(x => x.Id == Id);
        }

        public IActionResult OnPost()
        {
            if (Id == 0 || Service.Entities.Remove(Service.Entities.Single(x => x.Id == Id)))
            {
                if (Entity.Id == 0)
                    Entity.Id = Service.Entities.Max(x => x.Id) + 1;

                Service.Entities.Add(Entity);
            }

            return RedirectToPage("./Index");
        }
    }
}
