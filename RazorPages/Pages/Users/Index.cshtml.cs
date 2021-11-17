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
    public class IndexModel : PageModel
    {
        public Service<User> Service { get; }

        public IndexModel(Service<User> service)
        {
            Service = service;
        }

        public void OnGet()
        {
        }
    }
}
