using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantRTests.PlantRRef;

namespace PlantRTests
{

    [TestClass]
    public class ServiceConnectionTest : BaseTests
    {
        [TestMethod]
        public void ServiceConnectionTestMethod()
        {
            
            //Arrange
            int i = 5;
            Console.WriteLine("THIS IS A TEST!!!!");
            //Act
            string s = service.GetData(i);

            //Assert
            Assert.AreEqual($"You entered: {i}", s);
        }

    }

    [TestClass]
    public class PersonalPlantTests : BaseTests
    {

        [TestMethod]
        public void AddPlantToAccountTest()
        {
            //Arrange
            int plantID = 1002;
            int accID = 11;
            int daysWater = 5;
            string nName = "Planty";
            int result = 0;
            int ppID = 0;
            //Act
            ppID = service.AddPersonalPlant(plantID, accID, daysWater, nName);

            //Assert
            
            Assert.AreNotEqual(result, ppID);

            service.RemovePersonalPlant(ppID);

        }

        [TestMethod]
        public void RemovePlantFromAccountTest()
        {
            //Arrange
            int plantID = 1002;
            int accID = 11;
            int daysWater = 5;
            string nName = "Planty";
            bool result = false;
            int ppID = service.AddPersonalPlant(plantID, accID, daysWater, nName);
            //Act
            result = service.RemovePersonalPlant(ppID);

            //Assert
            
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindPlantFromAccountTest()
        {
            //Arrange
            int plantID = 1002;
            int accID = 11;
            int daysWater = 5;
            string nName = "Planty";
            PersonalPlant pp = null;
            int ppID = service.AddPersonalPlant(plantID, accID, daysWater, nName);
            //Act
            pp = service.FindPersonalPlant(ppID);

            //Assert

            Assert.AreEqual(pp.NName, nName);

            service.RemovePersonalPlant(ppID);
        }
        [TestMethod]
        public void UpdatePersonalPlantTest()
        {
            //Arrange
            int plantID = 1002;
            int accID = 11;
            int daysWater = 5;
            string nName = "Planty";
            string newName = "poopy";
            
            int ppID = service.AddPersonalPlant(plantID, accID, daysWater, nName);

            //Act
            bool result = service.UpdatePersonalPlant(ppID, daysWater, newName);
            PersonalPlant updatedPP = service.FindPersonalPlant(ppID); 
            //Assert

            Assert.IsTrue(result);
            Assert.AreEqual(updatedPP.NName, newName);

            service.RemovePersonalPlant(ppID);

        }

        [TestMethod]
        public void GetAllAccountPersonalPlantsTest()
        {
            //Arrange
            int plantID = 1002;
            int accID = 11;
            int daysWater = 5;
            string nName = "Planty";

            int plantID2 = 1002;
            int accID2 = 2002;
            int daysWater2 = 5;
            string nName2 = "Planty2";

            List<PersonalPlant> ppList = new List<PersonalPlant>();
            int expectedResult = 3;

            int ppid1 = service.AddPersonalPlant(plantID, accID, daysWater, nName);
            int ppid2 = service.AddPersonalPlant(plantID2, accID2, daysWater2, nName2);

            //Act

            ppList = service.GetAccountPersonalPlants(accID).ToList();

            int result = ppList.Count();

            //Assert

            Assert.AreEqual(result, expectedResult);

            service.RemovePersonalPlant(ppid1);
            service.RemovePersonalPlant(ppid2);
        }


    }

    [TestClass]
    public class AccountTests : BaseTests
    {
        [TestMethod]
        public void AddAccountTest()
        {
            //Arrange
            string email = "emailOG";

            //Act
            Account test = service.AddAccount(email);

            //Assert
            Assert.AreEqual(test.Email, email);

            service.RemoveAccount(email);
        }

        [TestMethod]
        public void FindAccountTest()
        {
            //Arrange
            string email = "emailOG";
            Account test = service.AddAccount(email);

            //Act
            Account result = service.FindAccount(email);

            //Assert
            Assert.AreEqual(email, result.Email);

            service.RemoveAccount(email);

        }

        [TestMethod]
        public void GetAllAccountsTest()
        {
            //Arrange
            string email = "emailOG";
            service.AddAccount(email);
            string email1 = "emailOG1";
            service.AddAccount(email1);
            List<Account> accounts = new List<Account>();
            //Act
            accounts = service.GetAllAccounts().ToList();
            //Assert
            Assert.AreNotEqual(0, accounts.Count());
            
            service.RemoveAccount(email);
            service.RemoveAccount(email1);

        }

        [TestMethod]
        public void RemoveAccountTest()
        {
            //Arrange
            string email = "emailOG";
            service.AddAccount(email);

            //Act
            bool result = service.RemoveAccount(email);

            //Assert
            Assert.IsTrue(result);

        }



    }

    [TestClass]
    public class PlantTest : BaseTests
    {
        [TestMethod]
        public void AddPlant()
        {
            //Arrange

            string cName = "commonName";
            string lName = "latinName";
            string imeURL = "www.URL.com";
            string description = "description";
            int sDays = 5;
            int result;
            //Act
            result = service.AddPlant(cName, lName, imeURL, description, sDays);
            //Assert
            Assert.IsTrue(result != 0);

            service.DeletePlant(result);

        }

        [TestMethod]
        public void DeletePlant()
        {
            //Arrange

            string cName = "commonName";
            string lName = "latinName";
            string imeURL = "www.URL.com";
            string description = "description";
            int sDays = 5;
            int id = service.AddPlant(cName, lName, imeURL, description, sDays);
            bool result;

            //Act

            result = service.DeletePlant(id);

            //Assert

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void FindPlant()
        {
            //Arrange

            string cName = "commonName";
            string lName = "latinName";
            string imeURL = "www.URL.com";
            string description = "description";
            int sDays = 5;
            int id = service.AddPlant(cName, lName, imeURL, description, sDays);

            //Act

            Plant p = service.FindPlant(id);

            //Assert

            Assert.AreEqual(p.CName, cName);

            service.DeletePlant(id);
        }

        [TestMethod]
        public void UpdatePlant()
        {
            //Assert
            string cName = "commonName";
            string lName = "latinName";
            string imeURL = "www.URL.com";
            string description = "description";
            int sDays = 5;
            int id = service.AddPlant(cName, lName, imeURL, description, sDays);

            //Act
            Plant p = service.UpdatePlant(id, "New name", lName, imeURL, description, sDays);


            //Assert
            Assert.AreEqual("New name", p.CName);

            service.DeletePlant(id);
        }

        [TestMethod]
        public void GetAllPlantsTest()
        {
            //Assert
            string cName = "commonName";
            string lName = "latinName";
            string imeURL = "www.URL.com";
            string description = "description";
            int sDays = 5;
            int id = service.AddPlant(cName, lName, imeURL, description, sDays);
            string cName1 = "commonName1";
            string lName1 = "latinName1";
            string imeURL1 = "www.URL.com1";
            string description1 = "description1";
            int sDays1 = 5;
            int id1 = service.AddPlant(cName1, lName1, imeURL1, description1, sDays1);
            List<Plant> plants = new List<Plant>();

            //Act
            plants = service.GetAllPlants().ToList();

            //Assert
            Assert.AreNotEqual(0, plants.Count());

            service.DeletePlant(id);
            service.DeletePlant(id1);
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
