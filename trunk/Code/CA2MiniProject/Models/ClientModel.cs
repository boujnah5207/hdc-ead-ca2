using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CA2MiniProject.Models
{
    public class MatchInfo
    {
        // The ID 
        [Required(ErrorMessage = "Not a Valid ID")]
        public String ID
        {
            get;
            set;
        }
        // Match Name
        [Range(-50, 50, ErrorMessage = "Not a Valid  Name")]
        public String Name
        {
            get;
            set;
        }
        // Match Age
        [Range(0, 200, ErrorMessage = "Not a Valid Age")]
        public int Age
        {
            get;
            set;
        }
        // Match Phone_Number    
        [Required(ErrorMessage = "Invalid Conditions")]
        public String Phone_Number
        {
            get;
            set;
        }
        // Match Email    
        [Required(ErrorMessage = "Invalid Conditions")]
        public String Email
        {
            get;
            set;
        }
        // Match Post_Code    
        [Required(ErrorMessage = "Invalid Conditions")]
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
        public String Looking_For
        {
            get;
            set;
        }
        // Match Interest_1    
        [Required(ErrorMessage = "Invalid Conditions")]
        public String Interest_1
        {
            get;
            set;
        }
        // Match Interest_2    
        [Required(ErrorMessage = "Invalid Conditions")]
        public String Interest_2
        {
            get;
            set;
        }
        // Match Interest_1    
        [Required(ErrorMessage = "Invalid Conditions")]
        public String Interest_3
        {
            get;
            set;
        }
    }
}