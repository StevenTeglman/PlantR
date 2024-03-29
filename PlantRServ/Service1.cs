﻿using System;
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
        //static StubADB stubADB = StubADB.Instance;
        //static StubPDB stubPDB = StubPDB.Instance;
        //static StubPPDB stubPPDB = StubPPDB.Instance;

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
        public List<Model.PersonalPlant> GetAllPersonalPlants()
        {
            /*List<Plant> plants = new List<Plant>();
            plants = stubPDB.plants;

            if (plants.Count == 0)
            {
                plants = null;
            }*/
            List<Model.PersonalPlant> result = new List<Model.PersonalPlant>();

            foreach (PersonalPlant pp in accrepo.GetAllPersonalPlants())
            {
                result.Add(ConvertPersonalPlant(pp));
            }

            return result;
        }

        /// <summary>
        /// Gets all the Personal PLants in the database, based on account ID
        /// </summary>
        /// <param name="accID">Account ID</param>
        /// <returns>Returns either a list of Personal Plants based on the,
        ///  entered ID, or else it will return null if nothing is found.</returns>
        public List<Model.PersonalPlant> GetAccountPersonalPlants(int accID)
        {
            /* List<PersonalPlant> ppList = new List<PersonalPlant>();
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


            return accrepo.GetAllAccountPersonalPlants(accID);
        }

        /// <summary>
        /// Find a single personal plant via PersonalPlant ID
        /// </summary>
        /// <param name="ppID">PersonalPlant ID</param>
        /// <returns>Returns the personal plant with the correct PersonalPlantID,
        ///  or it will return null if nothing is find.</returns>
        public Model.PersonalPlant FindPersonalPlant(int ppID)
        {
            /*PersonalPlant result = null;
            foreach (PersonalPlant pp in stubPPDB.personalPlants)
            {
                if (pp.Id == ppID)
                {
                    result = pp;
                    break;
                }
            }*/

            var pp = accrepo.FindPersonalPlant(ppID);

            Model.PersonalPlant result = ConvertPersonalPlant(pp);

            return result;
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

        public bool UpdatePersonalPlant(int ppID, int wDuration, string nName)
        {
            return accrepo.UpdatePersonalPlant(ppID, wDuration, nName);
        }

        public bool UpdatePersonalPlantDates(int ppid)
        {
            return accrepo.UpdatePersonalPlantDates(ppid);
        }
        #endregion

        // ------------------------------   Account    -------------------------------

        #region Account

        /// <summary>
        /// Creates and Adds a new account to the Database
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <returns></returns>
        public Model.Account AddAccount(string email)
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

            Model.Account account = ConvertAccount(accrepo.AddAccount(email));

            return account;
        }

        /// <summary>
        /// Find an account based the provided Account ID
        /// </summary>
        /// <param name="accID">Account ID</param>
        /// <returns>Returns either an Account if something is found,
        ///  or null if none are found.</returns>
        public Model.Account FindAccount(string email)
        {
            /* Account account = null;

             foreach (Account a in stubADB.accounts)
             {
                 if (a.ID == accID)
                 {
                     account = a;
                 }
             }*/
            Model.Account acc = ConvertAccount(accrepo.FindAccount(email));

            return acc;
        }

        /// <summary>
        /// Returns all the accounts in the Database
        /// </summary>
        /// <returns>Either all the accounts in the DB, or null if nothing found.</returns>
        public List<Model.Account> GetAllAccounts()
        {
            List<Model.Account> accounts = new List<Model.Account>();

            foreach (Account a in accrepo.GetAllAccounts())
            {
                accounts.Add(ConvertAccount(a));
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
        public Model.Plant FindPlant(int id)
        {
            return ConvertPlant(accrepo.FindPlant(id));
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
        public Model.Plant UpdatePlant(int id, string cName, string lName, string imageURL, string description, int sDays)
        {
            return ConvertPlant(accrepo.UpdatePlant(id, cName, lName, imageURL, description, sDays));
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
        public List<Model.Plant> GetAllPlants()
        {
            List<Model.Plant> allPlants = new List<Model.Plant>();

            foreach (Plant p in accrepo.GetAllPlants())
            {
                allPlants.Add(ConvertPlant(p));
            }

            return allPlants;
        }

        #endregion

        #region HelperMethods

        private Model.PersonalPlant ConvertPersonalPlant(PersonalPlant plant)
        {
            if (plant != null)
            {
                Model.PersonalPlant mPP = new Model.PersonalPlant
                {
                    Id = plant.id,
                    PId = plant.pid,
                    AId = plant.aid,
                    NName = plant.nname,
                    LastWatered = plant.lastwatered,
                    NextWatered = plant.nextwatered,
                    WDuration = plant.wduration,

                    account = ConvertAccount(plant.Account),
                    plant = ConvertPlant(plant.Plant)
                };

                return mPP;
            }
            else return null;


        }

        private Model.Plant ConvertPlant(Plant plant)
        {
            if (plant != null)
            {
                Model.Plant mPlant = new Model.Plant
                {
                    ID = plant.id,
                    LName = plant.lname,
                    CName = plant.cname,
                    ImageURL = plant.imgurl,
                    Description = plant.description,
                    SDays = plant.sdays
                };
                return mPlant;
            }
            else return null;

        }

        private Model.Account ConvertAccount(Account account)
        {
            if (account != null)
            {
                Model.Account mAccount = new Model.Account
                {
                    ID = account.id,
                    Email = account.email
                };

                return mAccount;
            }
            else return null;

        }


        #endregion
    }
}
       

