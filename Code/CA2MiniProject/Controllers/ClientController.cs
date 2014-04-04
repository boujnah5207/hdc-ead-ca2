// a RESFul service which reports Client information
// By Louise Foley X number here & Collin Walsh X00115912

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CA2MiniProject.Models;                  // Client information model class


namespace CA2MiniProject.Controllers
{
    public class ClientController : ApiController
    {
        /*
        * GET /api/client                  get client information                      GetAllClientInfo()
        * GET /api/client/name             get client information for name             GetClientInfoForCity(name)
        */

        private List<ClientInfo> client;

        // initialise the client collection, stateless
        public ClientController()
        {
            client = new List<ClientInfo>() 
                { 
                    new ClientInfo { ID = "x9864", Name = "Peter", Age = 22, Phone_Number = "087451237", Email = "peter@gmail.com", Post_Code = "D24", Gender = "Male", Looking_For = "Female", Interest_1 = "Sport", Interest_2 = "Music", Interest_3 = "Hiking" },
                    new ClientInfo { ID = "x9865", Name = "Frank", Age = 23, Phone_Number = "087451236", Email = "Frank@gmail.com", Post_Code = "D24", Gender = "Male", Looking_For = "Female", Interest_1 = "Sport", Interest_2 = "Music", Interest_3 = "Hiking" },
                };
        }

        // GET api/client
        public IEnumerable<ClientInfo> GetAllClientInfo()
        {
            return client;
        }

        // GET api/client/frank or api/client?name=frank
        public ClientInfo GetClientInfoForCity(String id)
        {
            // LINQ query, find matching name (case-insensitive) or default value (null) if none matching
            ClientInfo clientSearch = client.FirstOrDefault(w => w.ID.ToUpper() == id.ToUpper());
            if (clientSearch == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);       // translated into a http response status code 404
            }
            return clientSearch;
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
}