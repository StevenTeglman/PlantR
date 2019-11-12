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
        public List<PersonalPlant> personalPlants = new List<PersonalPlant>();
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

        }

    }
}
