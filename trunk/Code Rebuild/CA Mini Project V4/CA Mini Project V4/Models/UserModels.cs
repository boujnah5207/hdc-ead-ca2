using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;


namespace CA_Mini_Project_V4.Models
{


    // a class to hold the details of the dating website users
   
    public partial class UserInfo
    {

        public static string[] PostCodeOptions
        {
            get
            {
                return new String[] { "Dublin 1 ", "Dublin 2", "Dublin 3", "Dublin 4", "Dublin 5", "Dublin 6", "Dublin 7", "Dublin 8", "Dublin 9", "Dublin 10", "Dublin 11", "Dublin 12", "Dublin 13", "Dublin 14", "Dublin 15", "Dublin 16", "Dublin 18", "Dublin 20", "Dublin 22", "Dublin 24", "Kildare", "Meath", "Wicklow", "Other"};
            }
        }
        public static string[] Interest1Descriptions
        {
            get
            {
                return new String[] { "Music", "Current Affairs", "Environment" };
            }
        }

        public static string[] Interest2Descriptions
        {
            get
            {
                return new String[] { "Film", "History", "Cooking" };
            }
        }

        public static string[] Interest3Descriptions
        {
            get
            {
                return new String[] { "Sport", "Technology", "Charity Work" };
            }
        }

        // User ID 
        [Required(ErrorMessage = "Not a Valid ID")] // not null or empty string, not enforced automatically
        public string ID
        {
            get;
            set;
        }
        //User Name
        [Range(-50, 50, ErrorMessage = "Not a Valid Name")]
        public String Name
        {
            get;
            set;
        }
        // User Age
        [Range(18, 200, ErrorMessage = "Not a Valid Age")]
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                // validate input
                if (value > 18)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("User must be over 18");
                }
            }
        }

         
        // User Phone_Number    
        [Required(ErrorMessage = "Phone number must be entered")]
        [Display(Name = "Phone Number")]
        public String Phone_Number
        {
            get;
            set;
        }
        // User Email    
        [EmailAddress]
        [Required]
        [RegularExpression(@".*[@].*[\\.].*", ErrorMessage = "Must contain @ and .")]
        public String Email
        {
            get;
            set;
        }
        // user Post_Code    
        [Required(ErrorMessage = "Invalid Conditions")]
        [Display(Name = "Post Code")]
        public String Post_Code
        {
            get;
            set;
        }
        // User Gender    
        [Required(ErrorMessage = "Invalid Conditions")]
        public String Gender
        {
            get;
            set;
        }
        // User Looking_For    
        [Required(ErrorMessage = "Invalid Conditions")]
        [Display(Name = "Looking For")]
        public String Looking_For
        {
            get;
            set;
        }
        // User Interest_1    
        [Required(ErrorMessage = "Invalid Conditions")]
        [Display(Name = "1st Interest")]
        public String Interest_1
        {
            get;
            set;
        }
        // User Interest_2    
        [Required(ErrorMessage = "Invalid Conditions")]
        [Display(Name = "2nd interest")]
        public String Interest_2
        {
            get;
            set;
        }
        // User Interest_3    
        [Required(ErrorMessage = "Invalid Conditions")]
        [Display(Name = "3rd Interest")]
        public String Interest_3
        {
            get;
            set;
        }

        private AzureDatabaseEntities db = new AzureDatabaseEntities();

        public IEnumerable<User> FindMatch(string interest_1)
        {
            // query Users with the same Interest
            var myMatch = from x in db.Users
                          where x.Interest_1 == interest_1
                          select x;
            return myMatch;
        }
    }
}
