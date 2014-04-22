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



using CA2MiniProject.Models;                  // User information model class


namespace CA2MiniProject.Controllers
{
    public class UserController : ApiController
    {
        /*
        * GET /api/user                  get user information                      GetAllUserInfo()
        * GET /api/user/name             get user number for name                  GetUserNumber(name)
        */

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
        UserEntities context = new UserEntities();

        
        // GET api/User
        public IEnumerable<UserInfo> GetAllUserInfo()
        {
            return user;
        }

        // POST api/User, request body contains User information serialized as XML or JSON
        public HttpResponseMessage PostAddPerson(UserInfo UserSearch)
        {
            if (ModelState.IsValid)                                             // model class validation ok?
            {
                // check for duplicate
                // LINQ query - count number of people with ID
                int count = context.User.Where(l => l.ID.ToUpper() == UserSearch.ID.ToUpper()).Count();
                if (count == 0)
                {
                    UserInfo.Add(UserSearch);

                    // create http response with Created status code and listing serialised as content and Location header set to URI for new resource
                    var response = Request.CreateResponse<UserInfo>(HttpStatusCode.Created, UserSearch);
                    string uri = Url.Link("DefaultApi", new { id = UserSearch.ID });         // name of default route in WebApiConfig.cs
                    response.Headers.Location = new Uri(uri);                                           // Location URI for newly created resource

                    return response;
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);                // 404
                }
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);                 // 400, malformed request
            }
        }


        // GET api/match/frank or api/match?name=frank
        public String GetUserNumber(String name)
        {
            // LINQ query, find matching name (case-insensitive) or default value (null) if none matching
            UserInfo UserSearch = context.UserEntities.FirstOrDefault(w => w.Name.ToUpper() == name.ToUpper());
            if (UserSearch == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);       // translated into a http response status code 404
            }
            return UserSearch.Phone_Number;
        }

       

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

