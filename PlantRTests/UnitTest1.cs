using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantRTests.PlantRRef;

namespace PlantRTests
{
    [TestClass]
    public class PersonalPlantTests : BaseTests
    {

        [TestMethod]
        public void ServiceConnection()
        {
            //Arrange
            int i = 5;
            Console.WriteLine("THIS IS A TEST!!!!");
            //Act
            string s = service.GetData(i);

            //Assert
            Assert.AreEqual($"You entered: {i}", s);
        }

        [TestMethod]
        public void AddPlantToAccount()
        {
            //Arrange
            int plantID = 1;
            int accID = 777;
            int daysWater = 5;
            string nName = "Planty";
            //Act
            service.AddPersonalPlant(plantID, accID, daysWater, nName);

            //Assert
            PersonalPlant pp = service.GetLastPP();
            Assert.AreEqual(nName, pp.NName);

        }

        [TestMethod]
        public void RemovePlantFromAccount()
        {
            //Arrange
            int ppID = 1;
            int plantID = 1;
            int accID = 777;
            int daysWater = 5;
            string nName = "Planty";
            bool result = false;
            service.AddPersonalPlant(plantID, accID, daysWater, nName);
            //Act
            result = service.RemovePersonalPlant(ppID);

            //Assert
            
            Assert.IsTrue(result);
        }


    }

    [TestClass]
    public class AccountTests : BaseTests
    {
        [TestMethod]
        public void AddAccountTest()
        {
            //Arrange
            string userName = "Testy Tom";
            string email = "TomsTesties@tomsurology.dk";
            string password = "iLikeLegoland";

            //Act
            Account test = service.AddAccount(userName, email, password);

            //Assert
            Account expected = service.GetLastAccount();
            Assert.AreEqual(test.UserName, expected.UserName);
        }

        [TestMethod]
        public void FindAccountTest()
        {
            //Arrange
            int id = 99;
            Account result = null;

            //Act
            result = service.FindAccount(id);

            //Assert
            Assert.AreEqual("GiveUrBallsATug", result.Password);
        }

        [TestMethod]
        public void GetAllAccountsTest()
        {
            //Arrange

            //Act
            Account[] accounts = service.GetAllAccounts();
            //Assert
            Assert.IsNotNull(accounts);
        }

        [TestMethod]
        public void RemoveAccountTest()
        {
            //Arrange
            int ID = 777;
            bool result = false;

            //Act
            result = service.RemoveAccount(777);

            //Assert
            Assert.IsTrue(result);

        }

    }

    [TestClass]
    public abstract class BaseTests
    {
        public PlantRRef.Service1Client service = null;

        [TestInitialize]
        public void Setup()
        {
            Console.WriteLine("Setup executed.");
            service = new Service1Client();
            service.Open();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Console.WriteLine("Cleanup executed.");
            service.Close();
        }
    }
}
