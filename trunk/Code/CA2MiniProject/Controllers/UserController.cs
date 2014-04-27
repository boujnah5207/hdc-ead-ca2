// a RESFul service which reports User information
// By Louise Foley X0011597 number here & Collin Walsh X00115912

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Data.Entity;



using CA2MiniProject.Models;                  // User information model class


namespace CA2MiniProject.Controllers
{
    public class UserController : ApiController
    {
        /*
        * GET /api/user                  get user information                      GetAllUserInfo()
        * GET /api/user/name             get user number for name                  GetUserNumber(name)
        */

        private CA2MiniProjectContext db = new CA2MiniProjectContext();
        // GET api/User
        public List<User> Get()
        {
            return db.Users.ToList();
        }

        // GET api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/User
        public void Post([FromBody]string name)
        {
        }

        // PUT api/User/5
        public void Put(int id, [FromBody]string name)
        {
        }

        // DELETE api/User/5
        public void Delete(int id)
        {
        }

        //private List<UserInfo> User;

        //// initialise the User collection, stateless
        //public UserController()
        //{
        //    User = new List<UserInfo>() 
        //        { 
        //            new UserInfo { ID = "x9864", Name = "Peter", Age = 22, Phone_Number = "087451237", Email = "peter@gmail.com", Post_Code = "D24", Gender = "Male", Looking_For = "Female", Interest_1 = "Sport", Interest_2 = "Music", Interest_3 = "Hiking" },
        //            new UserInfo { ID = "x9865", Name = "Frank", Age = 23, Phone_Number = "087451236", Email = "Frank@gmail.com", Post_Code = "D24", Gender = "Male", Looking_For = "Female", Interest_1 = "Sport", Interest_2 = "Music", Interest_3 = "Hiking" },
        //        };
        //}

        //Initialize the ObjectContext
        //CA2MiniProjectContext db = new CA2MiniProjectContext();

        
        //// GET /User/

        //public ActionResult Index()
        //{
        //    var users = db.Users.ToList();
        //    return View(users);
        //}
        
        //public HttpResponseMessage GetAllUsers()
        //{
        //    var users = db.Users.ToList();
        //    if (users != null)
        //    {
        //        return users;
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }
        //}

        ////Post api/users add a new user

       
        //public HttpResponseMessage Post(UserInfo user)
        //{
        //    if ((this.ModelState.IsValid) && (user != null))
        //    {
        //        UserInfo newUser = this.context.CreateBook(user);
        //        if (newUser != null)
        //        {
        //            var httpResponse = Request.CreateResponse<UserInfo>(HttpStatusCode.Created, newUser);
        //            string uri = Url.Link("DefaultApi", new { id = newUser.ID });
        //            httpResponse.Headers.Location = new Uri(uri);
        //            return httpResponse;
        //        }
        //    }
        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}

        //// api/users/2 edit a users details

       
        //public HttpResponseMessage Put(String id, UserInfo user)
        //{
        //    if ((this.ModelState.IsValid) && (user != null) && (user.ID.Equals(id)))
        //    {
        //        UserInfo modifiedBook = this.context.UpdateBook(id, user);
        //        if (modifiedBook != null)
        //        {
        //            return Request.CreateResponse<UserInfo>(HttpStatusCode.OK, modifiedBook);
        //        }
        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound);
        //        }
        //    }
        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}



        //// GET User/frank or /User?name=frank
        //public HttpResponseMessage GetUserNumber(String name)
        //{
        //    // LINQ query, find matching name (case-insensitive) or default value (null) if none matching
        //    var UserSearch = context.UserEntities.FirstOrDefault(w => w.Name.ToUpper() == name.ToUpper());
        //    if (UserSearch == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);       // translated into a http response status code 404
        //    }
        //    return (UserSearch.Phone_Number);
        //}

        ///// Method to remove an existing user from the list.
        ///// Example: DELETE api/users/5
        ///// </summary>
       
        //public HttpResponseMessage Delete(String id)
        //{
        //    UserInfo user = this.context.GetUser(id);
        //    if (user != null)
        //    {
        //        if (this.context.DeleteUser(id))
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK);
        //        }
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}

    }
}

    //public class UserController : ApiController
    //{
    //    UserEntities UserDB = new UserEntities();                  // context object

    //    // lookup a name
    //    // GET /api/User/frank
    //    public String GetName(String name)
    //    {
    //        // LINQ query, find matching entry (case-insensitive) or default value (null) if none matching
    //        var UserEntry = UserDB.Users.FirstOrDefault(entry => (entry.Name.ToUpper() == name.ToUpper()));
    //        if (UserEntry == null)
    //        {
    //            throw new HttpResponseException(HttpStatusCode.NotFound);
    //        }
    //        return UserEntry.ToString();
    //    }
    //}

//}

