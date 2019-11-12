using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PlantRServ.DataAccess;
using PlantRServ.Model;

namespace PlantRServ
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public PersonalPlant AddPlant(AccountRepository repo, int plantID, int accID, int daysWater, string nName)
        {
            return repo.AddPlant(plantID, accID, daysWater, nName);
        }

        public Account GetAccount()
        {
            throw new NotImplementedException();
        }

        public AccountRepository GetAccountRepository()
        {
            return new AccountRepository();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public PersonalPlant GetLastPP(AccountRepository repo)
        {
            throw new NotImplementedException();
        }
    }
}
