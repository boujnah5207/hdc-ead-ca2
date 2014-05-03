using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Xml;
using System.Xml.Linq;

using System.Web;



namespace CA_Mini_Project_V4.Models
{
    // a class to hold the details of the dating website users
    public class UserInfo
    {

        public static string[] PostCodeOptions
        {
            get
            {
                return new String[] { "Antrim", "Armagh", "Carlow", "Cavan", "Clare", "Cork", "Derry", "Donegal", "Down", "Dublin", "Fermanagh", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath", "Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Tyrone", "Waterford", "Westmeath", "Wexford", "Wicklow" };
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


        public string ID
        {
            get;
            set;
        }
        
        public String Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }
   
        public String Phone_Number
        {
            get;
            set;
        }
     
        public String Email
        {
            get;
            set;
        }
    
        public String Post_Code
        {
            get;
            set;
        }
    
        public String Gender
        {
            get;
            set;
        }
 
      
        public String Looking_For
        {
            get;
            set;
        }
       
        public String Interest_1
        {
            get;
            set;
        }
   
        public String Interest_2
        {
            get;
            set;
        }

        public String Interest_3
        {
            get;
            set;
        }
    }
}
