using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace am108217MIS4200.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Alta McKim";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information for Alta McKim";

            return View();
        }
    }
}