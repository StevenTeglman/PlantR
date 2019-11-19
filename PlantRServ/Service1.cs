using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PlantRServ.DataAccess;
using PlantRServ.Model;
using Account = PlantRServ.DataAccess.Account;
using PersonalPlant = PlantRServ.DataAccess.PersonalPlant;
using Plant = PlantRServ.DataAccess.Plant;

namespace PlantRServ
{
    public class Service1 : IService1
    {
        AccountRepository accrepo = new AccountRepository();

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

        // ---------------------------   Personal Plant    ---------------------------

        #region PersonalPlant

        /// <summary>
        /// Adds a personal Plant to an account
        /// </summary>
        /// <param name="plantID">Plant ID</param>
        /// <param name="accID">Account ID</param>
        /// <param name="daysWater">Assigned days between waterings</param>
        /// <param name="nName">NickName</param>
        /// <returns>Returns the ID of the new Personal PLant</returns>
        public int AddPersonalPlant(int plantID, int accID, int daysWater, string nName)
        {
            /*Plant p = GetPlant(plantID);
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
            stubPPDB.personalPlants.Add(pp); // HACK: Obviously this will be replaced with the Database connection once the time comes */

            int result = accrepo.AddPersonalPlant(plantID, accID, daysWater, nName);
            
            return result;
        }

        /// <summary>
        /// Gets a list of all of the personal plants in the DB.
        /// Why do we want this? Not sure. When do we want it?
        /// NOW!
        /// </summary>
        /// <returns>Complete list of all the personal plants in DB</returns>
        public List<PersonalPlant> GetAllPersonalPlants()
        {
            /*List<Plant> plants = new List<Plant>();
            // HACK: To connect to data access layer later.
            plants = stubPDB.plants;

            if (plants.Count == 0)
            {
                plants = null;
            }*/

            return accrepo.GetAllPersonalPlants();
        }

        /// <summary>
        /// Gets all the Personal PLants in the database, based on account ID
        /// </summary>
        /// <param name="accID">Account ID</param>
        /// <returns>Returns either a list of Personal Plants based on the,
        ///  entered ID, or else it will return null if nothing is found.</returns>
        public List<PersonalPlant> GetAccountPersonalPlants(int accID)
        {
           /* List<PersonalPlant> ppList = new List<PersonalPlant>();
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
            }*/
            return null;
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
            /*PersonalPlant result = null;
            foreach (PersonalPlant pp in stubPPDB.personalPlants)
            {
                if (pp.Id == ppID)
                {
                    result = pp;
                    break;
                }
            }*/


            return accrepo.FindPersonalPlant(ppID);
        }

        /// <summary>
        /// Removes a PersonalPlant from the PersonalPlant Database
        /// </summary>
        /// <param name="ppID">The Personal Plant ID of the plant needed to be</param>
        /// <returns>Returns a boolean. True if successful, False if not.</returns>
        public bool RemovePersonalPlant(int ppID)
        {
            return accrepo.RemovePersonalPlant(ppID);
        }

        public PersonalPlant UpdatePersonalPlant(PersonalPlant pp)
        {
            return accrepo.UpdatePersonalPlant(pp.id, pp.wduration, pp.nname);
        }

        public bool UpdatePersonalPlant(PersonalPlant pp)
        {
            bool result = false;

            

            return result;
        }
        #endregion

        // ------------------------------   Account    -------------------------------

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
            /* Account account = null;

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
             }*/
            
            Account account = accrepo.AddAccount(userName, email, password);

            return account;
        }

        /// <summary>
        /// Find an account based the provided Account ID
        /// </summary>
        /// <param name="accID">Account ID</param>
        /// <returns>Returns either an Account if something is found,
        ///  or null if none are found.</returns>
        public Account FindAccount(string email)
        {
            /* Account account = null;

             foreach (Account a in stubADB.accounts)
             {
                 if (a.ID == accID)
                 {
                     account = a;
                 }
             }*/
            Account acc= accrepo.FindAccount(email);

            return acc;
        }

        /// <summary>
        /// Returns all the accounts in the Database
        /// </summary>
        /// <returns>Either all the accounts in the DB, or null if nothing found.</returns>
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();

            accounts = accrepo.GetAllAccounts();

            if (accounts.Count == 0)
            {
                accounts = null;
            }

            return accounts;
        }

        /// <summary>
        /// Removes the account with the provided Account ID from the DataBase
        /// </summary>
        /// <param name="accID">Account ID</param>
        /// <returns>Returns true if operation was successful, otherwise false</returns>
        public bool RemoveAccount(string email)
        {
            return accrepo.RemoveAccount(email);
        }

        /// <summary>
        /// Just a class for testing. Get's the last Personal Plant
        /// in the list.
        /// </summary>
        /// <returns>The last personal plant in the lsit</returns>
        public Account GetLastAccount()
        {
            return stubADB.accounts.Last<Account>();
        }

        #endregion

        // -------------------------------   Plants    --------------------------------
        #region Plant

        /// <summary>
        /// Adds a plant to the database, that can then be used by users to add personal
        /// plants. Returns the plant ID of the plant that was added.
        /// </summary>
        /// <param name="cName">Common Name</param>
        /// <param name="lName">Latin Name</param>
        /// <param name="imageURL">Image URL</param>
        /// <param name="description">Description</param>
        /// <param name="sDays">Suggested Watering Days</param>
        /// <returns>The Plant ID. Returns 0 if not successful</returns>
        public int AddPlant(string cName, string lName, string imageURL, string description, int sDays)
        {
            return accrepo.AddPlant(cName, lName, imageURL, description, sDays);
        }

        /// <summary>
        /// Finds the plant by ID
        /// </summary>
        /// <param name="id">Plant ID</param>
        /// <returns>Returns the requested plant</returns>
        public Plant FindPlant(int id)
        {
            return accrepo.FindPlant(id);
        }

        /// <summary>
        /// Updates the plant based on ID
        /// </summary>
        /// <param name="id">Plant ID</param>
        /// <param name="cName">Desired new name</param>
        /// <param name="lName">Desired new Latin Name</param>
        /// <param name="imageURL">Desired new Image URL</param>
        /// <param name="description">Desired new Description</param>
        /// <param name="sDays">Desiured new Watering days</param>
        /// <returns>Returns the updated plant</returns>
        public Plant UpdatePlant(int id, string cName, string lName, string imageURL, string description, int sDays)
        {
            return accrepo.UpdatePlant(id, cName, lName, imageURL, description, sDays);
        }

        /// <summary>
        /// Deletes the plant with the corresponding ID
        /// </summary>
        /// <param name="id">The plant ID</param>
        /// <returns>Returns true if successful, or false if not.</returns>
        public bool DeletePlant(int id)
        {
            return accrepo.DeletePlant(id);
        }

        /// <summary>
        /// Returns all the plants in the Database 
        /// </summary>
        /// <returns>Either all the plants in the DB, or null if nothing found.</returns>
        public List<Plant> GetAllPlants()
        {
            return accrepo.GetAllPlants();
        }

        #endregion

       
}
