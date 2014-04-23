using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Web;


namespace CA2MiniProject.Models
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

        // User ID 
        [Required(ErrorMessage = "Not a Valid ID")]
        public String ID
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
        public int Age
        {
            get;
            set;
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
    }

    // Define an interface which contains the methods for the user list.
    public interface IUserList
    {
        UserInfo CreateUser(UserInfo user);
        IEnumerable<UserInfo> GetAllUsers();
        UserInfo GetUser(String ID);
        UserInfo EditUser(String ID, UserInfo user);
        Boolean DeleteUser(String ID);
    }

    //Define a class based on the user list interface which contains the method implementations.
   
    public class UserList : IUserList
    {
        private string xmlFilename = null;
        private XDocument xmlDocument = null;

       
        // Define the class constructor.
       
        public UserList()
        {
            try
            {
                // Determine the path to the XmlUser.xml file.
                xmlFilename = HttpContext.Current.Server.MapPath("~/app_data/XMLUser.xml");
                // Load the contents of the XMLUser.xml file into an XDocument object.
                xmlDocument = XDocument.Load(xmlFilename);
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }

        // Method to add a new User to the list.
        // Defines the implementation of the POST method.

         public UserInfo CreateUser(UserInfo user)
        {
            try
            {
                // Retrieve the user with the highest ID from the list.
                var highestUser = (
                    from NewUser in xmlDocument.Elements("List").Elements("user")
                    orderby NewUser.Attribute("ID").Value descending
                    select NewUser).Take(1);
                // Extract the ID from the user data.
                string highestId = highestUser.Attributes("ID").First().Value;
                // Create an ID for the new user.
                string newId = "D" + (Convert.ToInt32(highestId.Substring(2)) + 1).ToString();
                // Verify that this user ID does not currently exist.
                if (this.GetUser(newId) == null)
                {
                    // Retrieve the parent element for the user list.
                    XElement userListRoot = xmlDocument.Elements("list").Single();
                    // Create a new user instance.
                    XElement newUser = new XElement("user", new XAttribute("ID", newId));
                    // Create elements for each of the user's data items.
                    XElement[] userInfo = FormatUserData(user);
                    // Add the element to the book element.
                    newUser.ReplaceNodes(userInfo);
                    // Append the new book to the XML document.
                    userListRoot.Add(newUser);
                    // Save the XML document.
                    xmlDocument.Save(xmlFilename);
                    // Return an object for the newly-added book.
                    return this.GetUser(newId);
                }
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
            // Return null to signify failure.
            return null;
        }

       
        /// Method to retrieve all of the users on the list.
        /// Defines the implementation of the non-specific GET method.
      
        public IEnumerable<UserInfo> GetAllUsers()
        {
            try
            {
                // Return a list that contains the list of User ids/names.
                return (
                    // Query the list of users.
                    from user in xmlDocument.Elements("List").Elements("user")
                    // Sort the list based on user IDs.
                    orderby user.Attribute("ID").Value ascending
                    // Create a new instance of the detailed user information class.
                    select new UserInfo
                    {
                        // Populate the class with data from each of the user's elements.
                        ID = user.Attribute("id").Value,
                        Name = user.Attribute("name").Value, 
                        Age = user.Attribute("age").Value, 
                        Phone_Number = user.Attribute("phoneNumber").Value,
                        Email = user.Attribute("email").Value,
                        Post_Code=user.Attribute("postCode").Value,
                        Gender=user.Attribute("gender").Value,
                        Looking_For=user.Attribute("lookingFor").Value,
                        Interest_1=user.Attribute("interest1").Value,
                        Interest_2=user.Attribute("interest2").Value,
                        Interest_3=user.Attribute("interest3").Value
                    }).ToList();
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }

        /// <summary>
        /// Method to retrieve a specific user from the list.
        /// Defines the implementation of the ID-specific GET method.
        /// </summary>
        public UserInfo GetUser(String id)
        {
            try
            {
                // Retrieve a specific user from the list.
                return (
                    // Query the list of users.
                    from user in xmlDocument.Elements("list").Elements("user")
                    // Specify the specific user ID to query.
                    where user.Attribute("id").Value.Equals(id)
                    // Create a new instance of the detailed user information class.
                    select new UserInfo
                    {
                        // Populate the class with data from each of the book's elements.
                       
                        ID = user.Attribute("id").Value,
                        Name = user.Attribute("name").Value, 
                        Age = user.Attribute("age").Value, 
                        Phone_Number = user.Attribute("phoneNumber").Value,
                        Email = user.Attribute("email").Value,
                        Post_Code=user.Attribute("postCode").Value,
                        Gender=user.Attribute("gender").Value,
                        Looking_For=user.Attribute("lookingFor").Value,
                        Interest_1=user.Attribute("interest1").Value,
                        Interest_2=user.Attribute("interest2").Value,
                        Interest_3=user.Attribute("interest3").Value
                    }).Single();
            }
            catch
            {
                // Return null to signify failure.
                return null;
            }
        }

        /// <summary>
        /// Populates a user UserInfo class with the data for a user.
        /// </summary>
        private XElement[] FormatBookData(UserInfo user)
        {
            XElement[] bookInfo =
            {
                new XElement("name", user.Name),
                new XElement("age", user.Age),
                new XElement("phoneNumber", user.Phone_Number),
                new XElement("email", user.Email),
                new XElement("postCode", user.Post_Code),
                new XElement("gender", user.Gender),
                new XElement("lookingFor", user.Looking_For),
                new XElement("interest1", user.Interest_1),
                new XElement("interest1", user.Interest_2),
                new XElement("interest1", user.Interest_3)
            };
            return userInfo;
        }

        /// <summary>
        /// Method to update an existing user in the catalog.
        /// Defines the implementation of the PUT method.
        /// </summary>
        public UserInfo EditUser(String id, UserInfo user)
        {
            try
            {
                // Retrieve a specific user from the catalog.
                XElement EditUser = xmlDocument.XPathSelectElement(String.Format("list/user[@id='{0}']", id));
                // Verify that the user exists.
                if (EditUser != null)
                {
                    // Create elements for each of the user's data items.
                    XElement[] userInfo = FormatUserData(user);
                    // Add the element to the book element.
                    EditUser.ReplaceNodes(userInfo);
                    // Save the XML document.
                    xmlDocument.Save(xmlFilename);
                    // Return an object for the updated book.
                    return this.GetUser(id);
                }
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
            // Return null to signify failure.
            return null;
        }

        /// <summary>
        /// Method to remove an existing user from the catalog.
        /// Defines the implementation of the DELETE method.
        /// </summary>
        public Boolean DeleteUser(String id)
        {
            try
            {
                if (this.GetUser(id) != null)
                {
                    // Remove the specific child node from the catalog.
                    xmlDocument
                        .Elements("List")
                        .Elements("user")
                        .Where(x => x.Attribute("id").Value.Equals(id))
                        .Remove();
                    // Save the XML document.
                    xmlDocument.Save(xmlFilename);
                    // Return a success status.
                    return true;
                }
                else
                {
                    // Return a failure status.
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }
    }
}

}


