//By Colin Walsh x00115912 Louise Foley X00115907
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
        // Homepage Navigation
        public ActionResult Index()
        {
            

            return View();
        }
        // About Page Navigation
        public ActionResult About()
        {
           

            return View();
        }
        // Contact Page Navigation
        public ActionResult Contact()
        {
            

            return View();
        }
    }
}
