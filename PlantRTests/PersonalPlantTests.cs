using System;
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

}
