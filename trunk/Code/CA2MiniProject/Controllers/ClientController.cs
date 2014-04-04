// a RESFul service which reports Client information
// By Louise Foley X number here & Collin Walsh X00115912

using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET api/client/Dublin or api/client?city=Dublin
        public ClientInfo GetClientInfoForCity(String id)
        {
            // LINQ query, find matching city (case-insensitive) or default value (null) if none matching
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
    //    // GET api/values
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET api/values/5
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/values
    //    public void Post([FromBody]string value)
    //    {
    //    }

    //    // PUT api/values/5
    //    public void Put(int id, [FromBody]string value)
    //    {
    //    }

    //    // DELETE api/values/5
    //    public void Delete(int id)
    //    {
    //    }
    //}
}