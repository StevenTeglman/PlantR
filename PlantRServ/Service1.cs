using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PlantRServ.DataAccess;
using PlantRServ.Model;

namespace PlantRServ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public List<Account> Accounts { get; set; }
        //TODO Connect to actual database
        static StubADB stubADB = StubADB.Instance;
        static StubPDB stubPDB = StubPDB.Instance;
        static StubPPDB stubPPDB = StubPPDB.Instance;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public PersonalPlant AddPlant(int plantID, int accID, int daysWater, string nName)
        {
            Plant p = GetPlant(plantID);
            PersonalPlant pp = new PersonalPlant
            {
                Id = 1, // HACK: Hardcoded ID, needs to be fixed once the DataBase is implemented
                ID = plantID, // HACK: Because of the inheritence, the Personal Plant seems to have two IDs. We should rename them.
                AId = accID,
                CName = p.CName,
                Description = p.Description,
                ImageURL = p.ImageURL,
                LastWatered = DateTime.Now,
                LName = p.LName,
                NextWatered = DateTime.Today.AddDays(daysWater),
                NName = nName,
                SDays = p.SDays,
                WDuration = daysWater
            };
            stubPPDB.personalPlants.Add(pp); // HACK: Obviously this will be replaced with the Database connection once the time comes 
            return pp;
        }
        public void GetAllPlants()
        {
            //TODO To connect to data access layer later.
            // Plants = StubPDB.GetAllPlants();
        }

        public void GetAccountPlants(int accID)
        {

        }
        /// <summary>
        /// Returns a Plant object based on the ID provided
        /// </summary>
        /// <param name="ID">The specific Plant ID</param>
        /// <returns>The desired plant</returns>
        public Plant GetPlant(int ID)
        {
            Plant result = null;
            foreach (Plant plant in stubPDB.plants)
            {
                if (plant.ID == ID)
                {
                    result = plant;
                }
            }
            return result;
        }
        /// <summary>
        /// Just a class for testing. Get's the last Personal Plant
        /// in the list.
        /// </summary>
        /// <returns>The last personal plant in the lsit</returns>
        public PersonalPlant GetLastPP()
        {
            return stubPPDB.personalPlants.Last();
        }


    }
}
