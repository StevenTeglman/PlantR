using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantRTests.PlantRRef;

namespace PlantRTests
{

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
