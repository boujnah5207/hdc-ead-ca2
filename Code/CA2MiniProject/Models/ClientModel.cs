using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CA2MiniProject.Models
{
 //   public class MatchContext : DbContext
 //{
 //       public MatchContext()
 //           : base("DefaultConnection")
 //       {
 //       }

 //       public DbSet<Client> Clients { get; set; }
    }

    public class MatchInfo
    {
    
        public static string[] PostCodeOptions
        {
            get
            {
                return new String[] { "Antrim", "Armagh", "Carlow", "Cavan", "Clare", "Cork", "Derry", "Donegal", "Down", "Dublin", "Fermanagh", "Galway", "Kerry", "Kildare", "Kilkenny", "Laois", "Leitrim", "Limerick", "Longford", "Louth", "Mayo", "Meath","Monaghan", "Offaly", "Roscommon", "Sligo", "Tipperary", "Tyrone", "Waterford", "Westmeath", "Wexford", "Wicklow" };
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

        // The ID 
        [Required(ErrorMessage = "Not a Valid ID")]
        public String ID
        {
            get;
            set;
        }
        // Match Name
        [Range(-50, 50, ErrorMessage = "Not a Valid Name")]
        public String Name
        {
            get;
            set;
        }
        // Match Age
        [Range(18, 200, ErrorMessage = "Not a Valid Age")]
        public int Age
        {
            get;
            set;
        }
        // Match Phone_Number    
        [Required(ErrorMessage = "Phone number must be entered")]
        [Display(Name = "Phone Number")]
        public String Phone_Number
        {
            get;
            set;
        }
        // Match Email    
        [Required]
        [RegularExpression(@".*[@].*[\\.].*", ErrorMessage = "Must contain @ and .")]
        public String Email
        {
            get;
            set;
        }
        // Match Post_Code    
        [Required(ErrorMessage = "Invalid Conditions")]
        [Display(Name = "Post Code")]
        public String Post_Code
        {
            get;
            set;
        }
        // Match Gender    
        [Required(ErrorMessage = "Invalid Conditions")]
        public String Gender
        {
            get;
            set;
        }
        // Match Looking_For    
        [Required(ErrorMessage = "Invalid Conditions")]
        [Display(Name = "Looking For")]
        public String Looking_For
        {
            get;
            set;
        }
        // Match Interest_1    
        [Required(ErrorMessage = "Invalid Conditions")]
        [Display(Name = "1st Interest")]
        public String Interest_1
        {
            get;
            set;
        }
        // Match Interest_2    
        [Required(ErrorMessage = "Invalid Conditions")]
        [Display(Name = "2nd interest")]
        public String Interest_2
        {
            get;
            set;
        }
        // Match Interest_1    
        [Required(ErrorMessage = "Invalid Conditions")]
        [Display(Name = "3rd Interest")]
        public String Interest_3
        {
            get;
            set;
        }
    }

