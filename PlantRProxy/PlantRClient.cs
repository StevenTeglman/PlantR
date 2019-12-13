using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PlantRServ;
using PlantRServ.Model;

namespace PlantRProxy
{
    public class PlantRClient : ClientBase<PlantRServ.IService1>, PlantRServ.IService1
    {
        static void Main(string[] args) { }
        public Account AddAccount(string email)
        {
            return Channel.AddAccount(email);
        }

        public int AddPersonalPlant(int plantID, int accID, int daysWater, string nName)
        {
            return Channel.AddPersonalPlant(plantID,accID,daysWater,nName);
        }

        public int AddPlant(string cName, string lName, string imageURL, string description, int sDays)
        {
            return Channel.AddPlant(cName,lName,imageURL,description,sDays);
        }

        public bool DeletePlant(int id)
        {
            return Channel.DeletePlant(id);
        }

        public Account FindAccount(string email)
        {
            return Channel.FindAccount(email);
        }

        public PersonalPlant FindPersonalPlant(int ppID)
        {
            return Channel.FindPersonalPlant(ppID);
        }

        public Plant FindPlant(int id)
        {
            return Channel.FindPlant(id);
        }

        public List<PersonalPlant> GetAccountPersonalPlants(int accID)
        {
            return Channel.GetAccountPersonalPlants(accID);
        }

        public List<Account> GetAllAccounts()
        {
            return Channel.GetAllAccounts();
        }

        public List<PersonalPlant> GetAllPersonalPlants()
        {
            return Channel.GetAllPersonalPlants();
        }

        public List<Plant> GetAllPlants()
        {
            return Channel.GetAllPlants();
        }

        public string GetData(int value)
        {
            return Channel.GetData(value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            return Channel.GetDataUsingDataContract(composite);
        }

        public bool RemoveAccount(string email)
        {
            return Channel.RemoveAccount(email);
        }

        public bool RemovePersonalPlant(int ppID)
        {
            return Channel.RemovePersonalPlant(ppID);
        }

        public bool UpdatePersonalPlant(int ppID, int wDuration, string nName)
        {
            return Channel.UpdatePersonalPlant(ppID,wDuration,nName);
        }

        public bool UpdatePersonalPlantDates(int ppid)
        {
            return Channel.UpdatePersonalPlantDates(ppid);
        }

        public Plant UpdatePlant(int id, string cName, string lName, string imageURL, string description, int sDays)
        {
            return Channel.UpdatePlant(id,cName,lName,imageURL,description,sDays);
        }
    }
}
