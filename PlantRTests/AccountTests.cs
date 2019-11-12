using PlantRServ;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantRTests.PlantRRef;

namespace PlantRTests
{
    [TestClass]
    public class AccountTests : BaseTests
    {
        [TestMethod]
        public void ServiceConnection()
        {
            //Arrange
            Setup();
            int i = 5;
            Console.WriteLine("THIS IS A TEST!!!!");
            //Act
            string s = service.GetData(i);

            //Assert
            Assert.AreEqual($"You entered: {i}", s);
            Cleanup();
        }

        [TestMethod]
        public void AddAccount()
        {
            //Arrange
            Setup();
            string userName = "Testy";
            string email = "Testy@testMail.ca";
            string password = "testword";

            
            //Act
            

            //Assert
            Cleanup();
        }

        [TestMethod]
        public void RemoveAccount()
        {
            //Arrange

            //Act

            //Assert

        }


    }

}
