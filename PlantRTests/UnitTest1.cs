using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.AreEqual(nName, pp.nname);

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
            string userName = "usernameOG";
            string email = "emailOG";
            string password = "passwordOG";

            //Act
            Account test = service.AddAccount(userName, email, password);

            //Assert
            Assert.AreEqual(test.username, userName);

            service.RemoveAccount(email);
        }

        [TestMethod]
        public void FindAccountTest()
        {
            //Arrange
            string userName = "usernameOG";
            string email = "emailOG";
            string password = "passwordOG";
            Account test = service.AddAccount(userName, email, password);

            //Act
            Account result = service.FindAccount(email);

            //Assert
            Assert.AreEqual(password, result.password);

            service.RemoveAccount(email);

        }

        [TestMethod]
        public void GetAllAccountsTest()
        {
            //Arrange
            string userName = "usernameOG";
            string email = "emailOG";
            string password = "passwordOG";
            service.AddAccount(userName, email, password);
            string userName1 = "usernameOG1";
            string email1 = "emailOG1";
            string password1 = "passwordOG1";
            service.AddAccount(userName1, email1, password1);
            List<Account> accounts = new List<Account>();
            //Act
            accounts = service.GetAllAccounts().ToList();
            //Assert
            Assert.IsNotNull(accounts);
            Assert.AreEqual(3, accounts.Count());
            
            service.RemoveAccount(email);
            service.RemoveAccount(email1);

        }

        [TestMethod]
        public void RemoveAccountTest()
        {
            //Arrange
            string userName = "usernameOG";
            string email = "emailOG";
            string password = "passwordOG";
            Account test = service.AddAccount(userName, email, password);

            //Act
            bool result = service.RemoveAccount(email);

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
