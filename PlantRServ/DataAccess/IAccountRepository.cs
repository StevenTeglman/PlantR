using PlantRServ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PlantRServ.DataAccess
{
    [ServiceContract]
    interface IAccountRepository
    {
        [OperationContract]
        PersonalPlant AddPlant(int plantID, int accID, int daysWater, string nName);
        [OperationContract]
        void GetAllPlants();
        [OperationContract]
        void GetAccountPlants(int accID);
        [OperationContract]
        Plant GetPlant(int ID);

    }
}
