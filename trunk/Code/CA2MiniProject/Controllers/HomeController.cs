using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2MiniProject.Models;

namespace CA2MiniProject.Controllers
{
    public class HomeController : Controller
    {
        // Post to add a new person to db  /Home/EditPage
        [HttpPost]
        public ActionResult EditPage(Match match)
        {
            try
            {
                 if (ModelState.IsValid)
                 {
                     db.Match.Add(match);
                     db.SaveChanges();
                      return RedirectToAction("EditPage");
                 }
            }
            catch (Exception e)
            {
                if (e.InnerException.InnerException.Message.Contains("ID"))
                {
                    ModelState.AddModelError("ID", "ID must be unique.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }

                ViewBag.Match = match;
                ViewBag.Post_Code = new SelectList(MatchInfo.PostCodeOptions);
                ViewBag.Interest_1 = new SelectList(MatchInfo.Interest1Descriptions);
                ViewBag.Interest_2 = new SelectList(MatchInfo.Interest2Descriptions);
                ViewBag.Interest_3 = new SelectList(MatchInfo.Interest3Descriptions);
                return View();
            
        }

        // Get to return existing person from ID /Home/Find
    [HttpGet]
        public ActionResult Find(int ID = 0)
        {
            Match match = db.Match.Find(ID);
            if (match == null)
            {
                return HttpNotFound();
            }
            
            return View(match);
        }

    }
}

