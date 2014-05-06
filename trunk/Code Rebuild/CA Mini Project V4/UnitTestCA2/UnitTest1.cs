using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CA_Mini_Project_V4.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UserMVCUnitTests
    {
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
        public void APIUserGet_Returns_ViewResult()
        {
            // Arrange
            var controller = new UserMVCController();

            // Act
            var result = controller.Details("x09783") as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewName);
            //Assert.AreEqual("Details", result.ViewName);
        }
    }
}