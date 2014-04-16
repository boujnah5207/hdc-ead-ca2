// a RESFul service which reports Client information
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



using CA2MiniProject.Models;                  // Client information model class


namespace CA2MiniProject.Controllers
{
    public class MatchController : Controller
    {
        /*
        * GET /api/match                  get match information                      GetAllMatchInfo()
        * GET /api/match/name             get match number for name                  GetMatchNumber(name)
        */

        //private List<MatchInfo> match;

        //// initialise the match collection, stateless
        //public MatchController()
        //{
        //    match = new List<MatchInfo>() 
        //        { 
        //            new MatchInfo { ID = "x9864", Name = "Peter", Age = 22, Phone_Number = "087451237", Email = "peter@gmail.com", Post_Code = "D24", Gender = "Male", Looking_For = "Female", Interest_1 = "Sport", Interest_2 = "Music", Interest_3 = "Hiking" },
        //            new MatchInfo { ID = "x9865", Name = "Frank", Age = 23, Phone_Number = "087451236", Email = "Frank@gmail.com", Post_Code = "D24", Gender = "Male", Looking_For = "Female", Interest_1 = "Sport", Interest_2 = "Music", Interest_3 = "Hiking" },
        //        };
        //}

        //Initialize the ObjectContext
        ClientEntities context = new ClientEntities();

        
        // GET api/match
        public IEnumerable<MatchInfo> GetAllMatchInfo()
        {
            return match;
        }

        // POST api/Match, request body contains client information serialized as XML or JSON
        public HttpResponseMessage PostAddPerson(MatchInfo matchSearch)
        {
            if (ModelState.IsValid)                                             // model class validation ok?
            {
                // check for duplicate
                // LINQ query - count number of people with ID
                int count = context.Match.Where(l => l.ID.ToUpper() == matchSearch.ID.ToUpper()).Count();
                if (count == 0)
                {
                    MatchInfo.Add(matchSearch);

                    // create http response with Created status code and listing serialised as content and Location header set to URI for new resource
                    var response = Request.CreateResponse<MatchInfo>(HttpStatusCode.Created, matchSearch);
                    string uri = Url.Link("DefaultApi", new { id = matchSearch.ID });         // name of default route in WebApiConfig.cs
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
        public String GetMatchNumber(String name)
        {
            // LINQ query, find matching name (case-insensitive) or default value (null) if none matching
            MatchInfo matchSearch = context.ClientEntities.FirstOrDefault(w => w.Name.ToUpper() == name.ToUpper());
            if (matchSearch == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);       // translated into a http response status code 404
            }
            return matchSearch.Phone_Number;
        }

       

    }
}

    //public class ClientController : ApiController
    //{
    //    ClientEntities clientDB = new ClientEntities();                  // context object

    //    // lookup a name
    //    // GET /api/client/frank
    //    public String GetName(String name)
    //    {
    //        // LINQ query, find matching entry (case-insensitive) or default value (null) if none matching
    //        var clientEntry = clientDB.Clients.FirstOrDefault(entry => (entry.Name.ToUpper() == name.ToUpper()));
    //        if (clientEntry == null)
    //        {
    //            throw new HttpResponseException(HttpStatusCode.NotFound);
    //        }
    //        return clientEntry.ToString();
    //    }
    //}

//}

