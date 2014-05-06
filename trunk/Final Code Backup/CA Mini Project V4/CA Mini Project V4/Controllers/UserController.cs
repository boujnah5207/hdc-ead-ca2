﻿//This is an API RESTful Web service controller designed to connect to a Windows Phone Silverlight Project. 
//This controller contains the methods which retrieve data from a MicroSoft Azure Database.
//By Colin Walsh x00115912 Louise Foley X00115907
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CA_Mini_Project_V4.Models;

namespace CA_Mini_Project_V4.Controllers
{
    public class UserController : ApiController
    {
        /*
       * GET /api/user                  get all users information                GetAllUserInfo()
       * GET /api/user/id               get user details for id                  GetUserNumber(id)
       */


        private AzureDatabaseEntities db = new AzureDatabaseEntities();

        // GET api/User
        public IEnumerable<User> GetUsers()
        {
            return db.Users.AsEnumerable();
        }

        // GET api/User/x09782
        // finds the user and returns all other users with the same Interest_1
        public IEnumerable<User> GetUser(string id)
        {
            User user = db.Users.Find(id);                          //find the user by ID in the DB
            if (user == null)                                       //if none found Exception
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            UserInfo userInfo = new UserInfo();                                         
            IEnumerable<User> userIntrest = userInfo.FindMatch(user.Interest_1);        //Uses the FindMatch method to return all users with the same interest_1

            return userIntrest;
        }

        //the below code was auto generated and can be deleted. leaving it in place for the moment in case we want to add more funcionality

        //// PUT api/User/5
        //public HttpResponseMessage PutUser(string id, User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    if (id != user.ID)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    db.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //// POST api/User
        //public HttpResponseMessage PostUser(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Users.Add(user);
        //        db.SaveChanges();

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.ID }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //// DELETE api/User/5
        //public HttpResponseMessage DeleteUser(string id)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.Users.Remove(user);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, user);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}