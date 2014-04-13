//client for Client RESTful web service

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;



namespace MatchClient
{
    // listing for Match in Dating DataBase
    public class MatchInfo
    {
        // The ID 

        public String ID
        {
            get;
            set;
        }
        // Match Name

        public String Name
        {
            get;
            set;
        }
        // Match Age

        public int Age
        {
            get;
            set;
        }
        // Match Phone_Number    

        public String Phone_Number
        {
            get;
            set;
        }
        // Match Email    

        public String Email
        {
            get;
            set;
        }
        // Match Post_Code    

        public String Post_Code
        {
            get;
            set;
        }
        // Match Gender    

        public String Gender
        {
            get;
            set;
        }
        // Match Looking_For    

        public String Looking_For
        {
            get;
            set;
        }
        // Match Interest_1    

        public String Interest_1
        {
            get;
            set;
        }
        // Match Interest_2    

        public String Interest_2
        {
            get;
            set;
        }
        // match Interest_1    

        public String Interest_3
        {
            get;
            set;
        }
    }

    // test
    class Program
    {
        
        static void Main(string[] args)
        {
                try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:7252/");                             // base URL for API Controller i.e. RESTFul service

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    
                    // POST /api/match with a client serialised in request body
                    //// create a new listing for a new client
                    //MatchInfo newClient = new MatchInfo(); 
                    //HttpResponseMessage response1 = client.PostAsJsonAsync("api/client", newClient).Result;
                    //if (response.IsSuccessStatusCode)                                               // 200 .. 299
                    //{
                    //    Uri newStockUri = response.Headers.Location;
                    //    Console.WriteLine("URI for new resource: " + newStockUri.ToString());
                    //}
                    //else
                    //{
                    //    Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    //}

                    // GET ../api/match
                    // get all client listings
                    HttpResponseMessage response = client.GetAsync("api/match").Result;                 // accessing the Result property blocks
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read result 
                        var Match = response.Content.ReadAsAsync<IEnumerable<MatchInfo>>().Result;
                        foreach (var matchSearch in Match)
                        {
                            Console.WriteLine(matchSearch.Name + " " + matchSearch.Post_Code);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }


                    // GET ../api/Client/Frank
                    // get the phone number for Frank
                    response = client.GetAsync("api/match/frank").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        // read result 
                        string number = response.Content.ReadAsAsync<string>().Result;
                        Console.WriteLine(number);
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            
            }
        }
    }






  
    