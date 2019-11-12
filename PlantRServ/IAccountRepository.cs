using PlantRServ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PlantRServ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountRepository" in both code and config file together.
    [ServiceContract]
    public interface IAccountRepository
    {
        [OperationContract]
        PersonalPlant AddPlant(int plantID, int accID, int daysWater, string nName);
        [OperationContract]
        void GetAllPlants();
        [OperationContract]
        void GetAccountPlants(int accID);
        [OperationContract]
        Plant GetPlant(int ID);
        [OperationContract]
        PersonalPlant GetLastPP();
    }
}
