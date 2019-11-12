using PlantRServ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantRServ.DataAccess
{
    class StubPDB
    {
        public List<Plant> plants = new List<Plant>();
        private static StubPDB instance = null;

        public static StubPDB Instance {
            get {
                if (instance == null)
                {
                    instance = new StubPDB();
                }
                return instance;
            }
        }
        private StubPDB()
        {
            plants.Add(new Plant
            {
                CName = "Rose",
                Description = "Apparently everyone has its thorn, or something",
                ImageURL = "http://www.flowerpicturesfromMatesmum.com",
                LName = "Rosa",
                SDays = 7,
                ID = 1
            });

            plants.Add(new Plant
            {
                CName = "Tulip",
                Description = "Is it me, or do Tulips look like vaginas sometimes?",
                ImageURL = "http://www.flowerpicturesfromSaifsmum.com",
                LName = "Tulipa",
                SDays = 5,
                ID = 2
            });

            plants.Add(new Plant
            {
                CName = "Magnolia",
                Description = "Apparently these were eaten by dinosaurs, says Google.",
                ImageURL = "http://www.dinosaurstakingpicturesofflowers.com",
                LName = "Magnolia",
                SDays = 7,
                ID = 3
            });
        }
    }
}
