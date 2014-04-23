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
        // strongly typed view to test view 
        public ActionResult List()
        {
            var user = new List<User>
    {
        new User { 
            ID = "D1234", 
            Name = "John Dunn", 
            Age = 25, 
            Phone_Number = "0872582466",
            Email = "JohnDunn@Hotmil.com",
            Post_Code="Carlow",
            Gender="Male",
            Looking_For="Female",
            Interest_1="Music",
            Interest_2="Cooking",
            Interest_3="Sport"
        },
        new User { 
            ID = "D2345", 
            Name = "Ann Quinn", 
            Age = 28, 
            Phone_Number = "0872582422",
            Email = "Quinner@Hotmil.com",
            Post_Code="Waterford",
            Gender="Female",
            Looking_For="Male",
            Interest_1="Music",
            Interest_2="Cooking",
            Interest_3="Technology"
        },
        
    };

            // pass in message to view also
            ViewBag.Words = new List<string> { "User:"};
            return View(user);
        }


        // Get to return existing person from ID /Home/Find
        [HttpGet]
        // find a user based on Id
        public ActionResult Find(int ID = 0)
        {
           var user = UserInfo.Find(ID);
            if (User == null)
            {
                return HttpNotFound();
            }

            return View(User);
        }


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



    }
}

