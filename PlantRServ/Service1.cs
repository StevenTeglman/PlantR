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
    public class Service1 : IService1
    {

        #region ServiceInitialization

        public List<Account> Accounts { get; set; }
        //TODO Connect to actual database
        static StubADB stubADB = StubADB.Instance;
        static StubPDB stubPDB = StubPDB.Instance;
        static StubPPDB stubPPDB = StubPPDB.Instance;

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

        #endregion

        // ++++++++++++++++++++++++++++++   REPO CODE   ++++++++++++++++++++++++++++++

        // ---------------------------   PERSONAL PLANT    ---------------------------

        #region PersonalPlant


        public PersonalPlant AddPersonalPlant(int plantID, int accID, int daysWater, string nName)
        {
            Plant p = GetPlant(plantID);
            PersonalPlant pp = new PersonalPlant
            {
                Id = 1, // HACK: Hardcoded ID, needs to be fixed once the DataBase is implemented
                ID = plantID, // HACK: Because of the inheritence, the Personal Plant seems to have two IDs. We should rename them.
                AId = accID,
                CName = p.CName,
                Description = p.Description,
                ImageURL = p.ImageURL,
                LastWatered = DateTime.Now,
                LName = p.LName,
                NextWatered = DateTime.Today.AddDays(daysWater),
                NName = nName,
                SDays = p.SDays,
                WDuration = daysWater
            };
            stubPPDB.personalPlants.Add(pp); // HACK: Obviously this will be replaced with the Database connection once the time comes 
            return pp;
        }

        /// <summary>
        /// Get's a list of all of the Plants in the Database
        /// </summary>
        /// <returns>Returns all the plants in the Database, or null if,
        ///  none are found.</returns>
        public List<Plant> GetAllPlants()
        {
            List<Plant> plants = new List<Plant>();
            // HACK: To connect to data access layer later.
            plants = stubPDB.plants;

            if (plants.Count == 0)
            {
                plants = null;
            }

            return plants;
        }

        /// <summary>
        /// Gets all the Personal PLants in the database, based on account ID
        /// </summary>
        /// <param name="accID">Account ID</param>
        /// <returns>Returns either a list of Personal Plants based on the,
        ///  entered ID, or else it will return null if nothing is found.</returns>
        public List<PersonalPlant> GetAccountPlants(int accID)
        {
            List<PersonalPlant> ppList = new List<PersonalPlant>();
            // HACK: replace Stub with DB Access
            foreach (PersonalPlant pp in stubPPDB.personalPlants)
            {
                if (pp.AId == accID)
                {
                    ppList.Add(pp);
                }
            }
            if (ppList.Count == 0)
            {
                ppList = null;
            }
            return ppList;
        }

        /// <summary>
        /// Returns a Plant object based on the ID provided
        /// </summary>
        /// <param name="ID">The specific Plant ID</param>
        /// <returns>The desired plant</returns>
        public Plant GetPlant(int ID)
        {
            Plant result = null;
            foreach (Plant plant in stubPDB.plants)
            {
                if (plant.ID == ID)
                {
                    result = plant;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Just a class for testing. Get's the last Personal Plant
        /// in the list.
        /// </summary>
        /// <returns>The last personal plant in the lsit</returns>
        public PersonalPlant GetLastPP()
        {
            return stubPPDB.personalPlants.Last();
        }

        /// <summary>
        /// Find a single personal plant via PersonalPlant ID
        /// </summary>
        /// <param name="ppID">PersonalPlant ID</param>
        /// <returns>Returns the personal plant with the correct PersonalPlantID,
        ///  or it will return null if nothing is find.</returns>
        public PersonalPlant FindPersonalPlant(int ppID)
        {
            // HACK: This will of course talk to the DB
            PersonalPlant result = null;
            foreach (PersonalPlant pp in stubPPDB.personalPlants)
            {
                if (pp.Id == ppID)
                {
                    result = pp;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Removes a PersonalPlant from the PersonalPlant Database
        /// </summary>
        /// <param name="ppID">The Personal Plant ID of the plant needed to be</param>
        /// <returns>Returns a boolean. True if successful, False if not.</returns>
        public bool RemovePersonalPlant(int ppID)
        {
            bool result = false;

            PersonalPlant pp = FindPersonalPlant(ppID);
            result = stubPPDB.personalPlants.Remove(pp);

            return result;
        }
        #endregion

        // ------------------------------   ACCOUNT    -------------------------------

        #region Account

        /// <summary>
        /// Creates and Adds a new account to the Database
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="email">Email Address</param>
        /// <param name="password">Users Password</param>
        /// <returns></returns>
        public Account AddAccount(string userName, string email, string password)
        {
            Account account = null;

            account = new Account
            {
                UserName = userName,
                Email = email,
                Password = password,
                ID = 1 // HACK: This needs to be changed so it is automatically updated by the DB
            };
            try
            {
                stubADB.accounts.Add(account);
            }
            catch (Exception)
            {
                account = null;
                throw;
            }

            return account;
        }

        /// <summary>
        /// Find an account based the provided Account ID
        /// </summary>
        /// <param name="accID">Account ID</param>
        /// <returns>Returns either an Account if something is found,
        ///  or null if none are found.</returns>
        public Account FindAccount(int accID)
        {
            Account account = null;

            foreach (Account a in stubADB.accounts)
            {
                if (a.ID == accID)
                {
                    account = a;
                }
            }
            return account;
        }

        /// <summary>
        /// Returns all the accounts in the Database
        /// </summary>
        /// <returns>Either all the accounts in the DB, or null if nothing found.</returns>
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();

            accounts = stubADB.accounts;

            if (accounts.Count == 0)
            {
                accounts = null;
            }

            return null;
        }

        /// <summary>
        /// Removes the account with the provided Account ID from the DataBase
        /// </summary>
        /// <param name="accID">Account ID</param>
        /// <returns>Returns true if operation was successful, otherwise false</returns>
        public bool RemoveAccount(int accID)
        {
            bool result = false;

            Account account = FindAccount(accID);

            result = stubADB.accounts.Remove(account);

            return result;
        }

        #endregion
    }
}
