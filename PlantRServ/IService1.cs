using PlantRServ.Model;
using PlantRServ.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PersonalPlant = PlantRServ.DataAccess.PersonalPlant;
using Plant = PlantRServ.DataAccess.Plant;
using Account = PlantRServ.DataAccess.Account;

namespace PlantRServ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        // ++++++++++++++++++++++++++++++   REPO CODE   ++++++++++++++++++++++++++++++
        // ---------------------------   Personal Plants    ---------------------------

        [OperationContract]
        int AddPersonalPlant(int plantID, int accID, int daysWater, string nName);
        [OperationContract]
        Model.PersonalPlant FindPersonalPlant(int ppID);
        [OperationContract]
        List<Model.PersonalPlant> GetAllPersonalPlants();
        [OperationContract]
        List<Model.PersonalPlant> GetAccountPersonalPlants(int accID);
        [OperationContract]
        bool RemovePersonalPlant(int ppID);
        [OperationContract]
        bool UpdatePersonalPlant(int ppID, int wDuration, string nName);
        [OperationContract]
        bool UpdatePersonalPlantDates(int ppid);
        // ------------------------------   Accounts    -------------------------------
        [OperationContract]
        Model.Account AddAccount(string email);
        [OperationContract]
        Model.Account FindAccount(string email);
        [OperationContract]
        List<Model.Account> GetAllAccounts();
        [OperationContract]
        bool RemoveAccount(string email);
        [OperationContract]
        Model.Account GetLastAccount();
        // -------------------------------   Plants    --------------------------------
        [OperationContract]
        int AddPlant(string cName, string lName, string imageURL, string description, int sDays);
        [OperationContract]
        Model.Plant FindPlant(int id);
        [OperationContract]
        Model.Plant UpdatePlant(int id, string cName, string lName, string imageURL, string description, int sDays);
        [OperationContract]
        bool DeletePlant(int id);
        [OperationContract]
        List<Model.Plant> GetAllPlants();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "PlantRServ.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
