using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantRTests.PlantRRef;

namespace PlantRTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddPlantToAccount()
        {
            //Arrange
            PlantRRef.Service1Client service = new Service1Client();

            //Act
            string i = service.GetData(1);
            //PersonalPlant pp = service.AddPlant(2, 777, 7, "puppy");
            //Assert
            Console.WriteLine(i);
            Assert.AreEqual(i, "You entered: 1");
        }

        [TestMethod]
        public void RemovePlantToAccount()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
