using PlantRServ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantRServ.DataAccess
{
    class StubPPDB
    {
        public List<PersonalPlant> personalPlants { get; set; } = new List<PersonalPlant>();
        private static StubPPDB instance = null;

        public static StubPPDB Instance {
            get {
                if (instance == null)
                {
                    instance = new StubPPDB();
                }
                return instance;
            }
        }

        private StubPPDB()
        {
           /* personalPlants.Add(new PersonalPlant
            {
                ID=1,
                AId=99,
                CName = "Rose",
                Description = "Apparently everyone has its thorn, or something",
                ImageURL = "http://www.flowerpicturesfromMatesmum.com",
                LName = "Rosa",
                SDays = 7,
                LastWatered = DateTime.Now,
                NextWatered= DateTime.Now.AddDays(3),
                NName="Roseyrose",
                WDuration=3,
                Id=1
                
            });
            personalPlants.Add(new PersonalPlant
            {
                ID = 2,
                AId = 99,
                CName = "Tulip",
                Description = "Tulipingn",
                ImageURL = "http://www.flowerpicturesfromMatesmum.com",
                LName = "Tulipa",
                SDays = 7,
                LastWatered = DateTime.Now,
                NextWatered = DateTime.Now.AddDays(3),
                NName = "Tilly",
                WDuration = 3,
                Id = 2

            }); personalPlants.Add(new PersonalPlant
            {
                ID = 3,
                AId = 99,
                CName = "Magnolia",
                Description = "Magdelene died for this",
                ImageURL = "http://www.flowerpicturesfromMatesmum.com",
                LName = "Magni",
                SDays = 7,
                LastWatered = DateTime.Now,
                NextWatered = DateTime.Now.AddDays(3),
                NName = "Maggy",
                WDuration = 3,
                Id = 3

            }); ;*/

        }



    }
}
