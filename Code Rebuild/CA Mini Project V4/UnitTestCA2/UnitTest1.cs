using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CA_Mini_Project_V4.Models;
using CA_Mini_Project_V4.Controllers;

using System.Data;
using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace UnitTestProject1
{
    [TestClass]
    public class UserMVCUnitTests
    {
        private List<User> GetTestUsers()
        {
            var testProducts = new List<User>();
            testProducts.Add(new User { ID = "x09782", Name = "Peter", Age = 21, Phone_Number = "087234123", Email = " tester@tester.com ", Post_Code = "Dublin 1 ", Gender = "Male", Looking_For = "Female", Interest_1 = "Music", Interest_2 = "Film", Interest_3 = "Sport" });
            testProducts.Add(new User { ID = "x09783", Name = "Frank", Age = 21, Phone_Number = "087234123", Email = " tester@tester.com ", Post_Code = "Dublin 1 ", Gender = "Male", Looking_For = "Female", Interest_1 = "Music", Interest_2 = "Film", Interest_3 = "Sport" });
            testProducts.Add(new User { ID = "x09784", Name = "Tom", Age = 21, Phone_Number = "087234123", Email = " tester@tester.com ", Post_Code = "Dublin 1 ", Gender = "Male", Looking_For = "Female", Interest_1 = "Music", Interest_2 = "Film", Interest_3 = "Sport" });
            testProducts.Add(new User { ID = "x09785", Name = "Tina", Age = 21, Phone_Number = "087234123", Email = " tester@tester.com ", Post_Code = "Dublin 1 ", Gender = "Female", Looking_For = "Male", Interest_1 = "Music", Interest_2 = "Film", Interest_3 = "Sport" });


            return testProducts;
        }
        [TestMethod]
        public void Home_About_Returns_ViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Home_Contact_Returns_ViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void Home_Home_Returns_ViewResult()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void UserMVC_Index_Returns_ViewResult()
        {
            // Arrange
            var controller = new UserMVCController();

            // Act
            var result = controller.Details("x09783") as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewName);
            //Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void GetAllUSers_ShouldReturnAllUsers()
        {
            var testUsers = GetTestUsers();
            var controller = new UserController();

            var result = controller.GetUsers() as List<User>;
            Assert.AreEqual(testUsers.Count, result.Count);
        }

        //[TestMethod]
        //public void GetUSer_ShouldReturnUser()
        //{
        //    var testUsers = GetUser();
        //    var controller = new UserController("x09783");

        //    var result = controller.GetUsers() as List<User>;
        //    Assert.AreEqual(testUsers.Count, result.Count);
        //}
    }
}