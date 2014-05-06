using CA_Mini_Project_V4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA_Mini_Project_V4.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //ViewBag.Message = "test";

            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
