using PlantRServ.Model;
using PlantRServ.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
        PersonalPlant AddPersonalPlant(int plantID, int accID, int daysWater, string nName);
        [OperationContract]
        PersonalPlant FindPersonalPlant(int ppID);
        [OperationContract]
        List<Plant> GetAllPlants();
        [OperationContract]
        List<PersonalPlant> GetAccountPlants(int accID);
        [OperationContract]
        Plant GetPlant(int ID);
        [OperationContract]
        PersonalPlant GetLastPP();
        [OperationContract]
        bool RemovePersonalPlant(int ppID);
        // ------------------------------   Accounts    -------------------------------
        [OperationContract]
        Account AddAccount(string userName, string email, string password);
        [OperationContract]
        Account FindAccount(int accID);
        [OperationContract]
        List<Account> GetAllAccounts();
        [OperationContract]
        bool RemoveAccount(int accID);
        [OperationContract]
        Account GetLastAccount();
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
