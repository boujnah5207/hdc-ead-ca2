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
        public ActionResult EditPage(User user)
        {
            try
            {
                 if (ModelState.IsValid)
                 {
                     return RedirectToAction("Save", user);
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

                ViewBag.User = user;
                ViewBag.Post_Code = new SelectList(UserInfo.PostCodeOptions);
                ViewBag.Interest_1 = new SelectList(UserInfo.Interest1Descriptions);
                ViewBag.Interest_2 = new SelectList(UserInfo.Interest2Descriptions);
                ViewBag.Interest_3 = new SelectList(UserInfo.Interest3Descriptions);
                return View();
            
        }

        // Get to return existing person from ID /Home/Find
    [HttpGet]
        // find a user based on Id
        public ActionResult Find(int ID = 0)
        {
            User user = user.Find(ID);
            if (User == null)
            {
                return HttpNotFound();
            }
            
            return View(User);
        }

    }
}

