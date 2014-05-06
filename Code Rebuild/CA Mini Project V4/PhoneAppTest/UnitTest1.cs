using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using CA_Mini_Project_V4.Models;

namespace PhoneAppTest
{
    [TestClass]
    public class PhoneAppTests
    {
        private UserInfo user = new UserInfo();

        [TestInitialize]
        public void Initialize()
        {
            user = new UserInfo();
        }

        [TestMethod]
        public void AlwaysTrue()
        {
            Assert.IsTrue(true, "this method will always pass");
        }
        
        // test that the mainPage is create without errors
        [TestMethod]
        public void TestMainPageNotNull()
        {
            DatingPhoneApp.MainPage CPage = new DatingPhoneApp.MainPage();

            // Assert
            Assert.IsNotNull(CPage);
        }

        //test the returned data
        [TestMethod]
        public void CheckListForDataFirstTime()
        {
            DatingPhoneApp.MainPage CPage = new DatingPhoneApp.MainPage();
            Assert.AreEqual(CPage.Content, 0);

        }

        [TestCleanup]
        public void Cleanup()
        {
            user = null;
        }
    }
}
