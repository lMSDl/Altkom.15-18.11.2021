using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Controllers
{
    public class HelloWorldController : Controller
    {


        public IActionResult Index()
        {
            //using System.Web;
            //return HttpUtility.HtmlEncode("<p>Hello world!</p>");

            ViewData["param1"] = "ViewDataParam1";
            ViewBag.Param2 = "ViewBagParam2";

            ViewBag.for1 = 3;
            ViewBag.for2 = 8;

            return View((object)"ModelParam3");
        }
        public IActionResult Welcome(string name, string id)
        {
           // return $"<p>Hello {name}! Your id: {id}</p>";

            //return View();
           return RedirectToAction(nameof(Index));
        }
    }
}
