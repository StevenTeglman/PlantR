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
            PlantRRef.IAccountRepository service = new AccountRepositoryClient();

            //Act
            PersonalPlant pp = service.AddPlant(2, 777, 7, "puppy");
            //Assert
            Assert.AreEqual(pp, service.GetLastPP());
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
