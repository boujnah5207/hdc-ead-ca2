//This is an ASP.NET MVC 4 controller designed to generate a user interface through which the CRUD functionalities can be performed.

using CA_Mini_Project_V4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;

using System.Net.Http.Headers;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Data.Entity.Validation;

using System.Transactions;

//using System.Web.Security;
//using DotNetOpenAuth.AspNet;
//using Microsoft.Web.WebPages.OAuth;
//using WebMatrix.WebData;
//using CA_Mini_Project_V4.Filters;



namespace CA_Mini_Project_V4.Controllers
{
    public class UserMVCController : Controller
    {
        private AzureDatabaseEntities db = new AzureDatabaseEntities();

        // GET: UserMVC
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

       // this method creates a new entry in the database for a user. 
       
        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.Post_Code = new SelectList(UserInfo.PostCodeOptions);//drop down box for Post Code
            ViewBag.Interest_1 = new SelectList(UserInfo.Interest1Descriptions); //drop down box for interest
            ViewBag.Interest_2 = new SelectList(UserInfo.Interest2Descriptions); //drop down box for interest
            ViewBag.Interest_3 = new SelectList(UserInfo.Interest3Descriptions); //drop down box for interest
            return View();
        }

        //create it not working, not sure why

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,Phone_Number,Email,Post_Code,Gender,Looking_For,Interest_1,Interest_2,Interest_3")] User user)
        {
            try
            {

            if (ModelState.IsValid)
            {                
                db.Users.Add(user);               
                db.SaveChanges();
                //db.Entry(user).State = EntityState.Modified;
                return RedirectToAction("Index");
            }

            else
             {
                 ModelState.AddModelError("", "Registration criteria not met");
             }
         }
         catch (FormatException)
         {
             ModelState.AddModelError("", "Registration criteria not met");
         }
         return View();
            
        }

       
        // GET: UserMVC/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: UserMVC/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Post_Code = new SelectList(UserInfo.PostCodeOptions);
            ViewBag.Interest_1 = new SelectList(UserInfo.Interest1Descriptions);
            ViewBag.Interest_2 = new SelectList(UserInfo.Interest2Descriptions);
            ViewBag.Interest_3 = new SelectList(UserInfo.Interest3Descriptions);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age,Phone_Number,Email,Post_Code,Gender,Looking_For,Interest_1,Interest_2,Interest_3")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: UserMVC/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UserMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
