using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PlantRService.Model;
using PlantRService.DataAccess;

namespace PlantRService.DataAccess
{
    [ServiceContract]
    public class AccountRepository
    {

        //TODO Make into Singleton 
        public List<Account> Accounts { get; set; }
        //TODO Connect to actual database
        StubADB stubADB = new StubADB();


        [OperationContract]
        public PersonalPlant AddPlant(int plantID, int accID, int daysWater, string nName)
        {
            Account account = stubADB.GetAccountByID();



        }
        [OperationContract]
        public void GetAllPlants()
        {
            //TODO To connect to data access layer later.
            // Plants = StubPDB.GetAllPlants();
        }
        [OperationContract]
        public void GetAccountPlants(int accID)
        {
            List<PersonalPlant> ppList = StubPPDB.GetAllPlants(accID);
            foreach (var acc in Accounts)
            {
                if (acc.ID == accID)
                {
                    acc.PlantList = ppList;
                }
            }
        }



    }
}
