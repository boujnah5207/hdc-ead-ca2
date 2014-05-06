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
using System.Transactions;




namespace CA_Mini_Project_V4.Controllers
{
    public class UserMVCController : Controller
    {
        private AzureDatabaseEntities db = new AzureDatabaseEntities();

        // GET: UserMVC
        // Retuns all users in the DB
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // Calls the Create page, used to add a new user to the DB 
        public ActionResult Create()
        {
            
            ViewBag.Post_Code = new SelectList(UserInfo.PostCodeOptions);//drop down box for Post Code
            ViewBag.Interest_1 = new SelectList(UserInfo.Interest1Descriptions); //drop down box for interest
            ViewBag.Interest_2 = new SelectList(UserInfo.Interest2Descriptions); //drop down box for interest
            ViewBag.Interest_3 = new SelectList(UserInfo.Interest3Descriptions); //drop down box for interest
            return View();
        }


        // This method creates a new entry in the database for a user. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,Phone_Number,Email,Post_Code,Gender,Looking_For,Interest_1,Interest_2,Interest_3")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);              //returns the user to the homepage
        }


        // GET: UserMVC/Details/x09782
        // Find a given user and show the details of that user in the in the details page
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

        // GET: UserMVC/Edit/x09782
        // Find a given user and show the details of that user in the in the Edit page
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

        // User to store a new users or edited a users detials in the DB
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

        // GET: UserMVC/Delete/x09782
        // Finds a user in the DB and retuns their info
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

        // POST: UserMVC/Delete/x09782
        // Deletes a usere from the DB, asking for confirmation of the delete action first.
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
