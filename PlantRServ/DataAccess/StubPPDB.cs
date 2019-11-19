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
            personalPlants.Add(new PersonalPlant
            {
                /*ID=1,
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
                ppId=1*/
                
            });;

        }



    }
}
