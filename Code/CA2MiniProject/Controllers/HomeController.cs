using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2MiniProject.Models;

namespace CA2MiniProject.Controllers
{
    public class HomeController : Controller
    {   [HttpGet]
        public ActionResult EditPage()
        {
            ViewBag.PostCode = new SelectList(MatchInfo.PostCodeOptions);
            ViewBag.Interest1 = new SelectList(MatchInfo.Interest1Descriptions);
            ViewBag.Interest2 = new SelectList(Enumerable.Empty<SelectList>(),MatchInfo.Interest2Descriptions);
            ViewBag.Interest3 = new SelectList(Enumerable.Empty<SelectList>(), MatchInfo.Interest3Descriptions);
            return View();
        }
    }
}
