using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BogusService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace RazorPages.Pages.Users
{
    public class DeleteModel : PageModel
    {
        public Service<User> Service { get; }

        public User SelectedUser { get; set; }

        public DeleteModel(Service<User> service)
        {
            Service = service;
        }

        public IActionResult OnGet(int id)
        {
            SelectedUser = Service.Entities.SingleOrDefault(x => x.Id == id);
            if (SelectedUser == null)
                return NotFound();
            return Page();
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public IActionResult OnPost()
        {
            Service.Entities.Remove(Service.Entities.Single(x => x.Id == Id));
            return RedirectToPage("./Index");
        }
    }
}
