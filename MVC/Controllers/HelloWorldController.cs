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
        public string Index()
        {
            //using System.Web;
            return HttpUtility.HtmlEncode("Hello world!");
        }
        public string Welcome(string name, string id)
        {
            return HttpUtility.HtmlEncode($"Hello {name}! Your id: {id}");
        }
    }
}
