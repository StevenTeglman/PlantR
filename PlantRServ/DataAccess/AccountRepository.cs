using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PlantRServ.Model;
using PlantRServ.DataAccess;
using System.Data.SqlClient;
using System.Data.Linq;

namespace PlantRServ.DataAccess
{

    public class AccountRepository
    {
        private enum TableInUse
        {
            Account,
            Plant,
            PersonalPlant
        }
        public LinQtoSQLDataContext plantdb;
        public AccountRepository()
        {

        }

        // ------------------------------   Account    --------------------------------

        #region Account
        //Basic CRUD for Accounts - Add, Find, Remove Update - plus a method to return a List of all Accounts in DB
        public Account AddAccount(string userName, string email, string password)
        {
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                plantdb.LoadOptions = SetDataLoadOptions(TableInUse.Account);

                Account acc = new Account
                {
                    username = userName,
                    email = email,
                    password = password
                };

                plantdb.Accounts.InsertOnSubmit(acc);
                plantdb.SubmitChanges();

                return acc;
            }
        }

        public Account FindAccount(string email)
        {
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                plantdb.LoadOptions = SetDataLoadOptions(TableInUse.Account);
                Account result = plantdb.Accounts.First(e => e.email.Equals(email));

                return result;
            }
        }

        public Account FindAccount(int accID)
        {
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                plantdb.LoadOptions = SetDataLoadOptions(TableInUse.Account);
                Account result = plantdb.Accounts.First(e => e.id.Equals(accID));

                return result;
            }
        }

        public bool RemoveAccount(string email)
        {
            bool r = false;

            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                try
                {
                    Account result = plantdb.Accounts.First(e => e.email.Equals(email));

                    plantdb.Accounts.DeleteOnSubmit(result);
                    plantdb.SubmitChanges();

                    r = true;
                }
                catch (Exception)
                {
                    r = false;
                }
            }

            return r;
        }

        public List<Account> GetAllAccounts()
        {
            List<Account> result = new List<Account>();
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                plantdb.LoadOptions = SetDataLoadOptions(TableInUse.Account);
                result = plantdb.Accounts.ToList();
            }

            return result;
        }
        #endregion

        // -------------------------------   Plants    --------------------------------

        #region Plant
        //Basic CRUD for Plants - Add, Find, Delete, Update - plus a method to return a List of all Plants in DB
        public int AddPlant(string cName, string lName, string imageURL, string description, int sDays)
        {
            int result = 0;

            using(plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                try
                {
                    plantdb.LoadOptions = SetDataLoadOptions(TableInUse.Plant);
                    Plant plant = new Plant
                    {
                        cname = cName,
                        lname = lName,
                        imgurl = imageURL,
                        description = description,
                        sdays = sDays
                    };
                    plantdb.Plants.InsertOnSubmit(plant);
                    plantdb.SubmitChanges();
                    
                    result = plant.id;
                }
                catch (Exception)
                {
                    result = 0;
                }
            }

            return result;
        }

        public Plant FindPlant(int id)
        {
            Plant result = null;

            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {

                try
                {
                    plantdb.LoadOptions = SetDataLoadOptions(TableInUse.Plant);
                    result = plantdb.Plants.First(e => e.id.Equals(id));
                }
                catch (Exception)
                {
                    result = null;
                }
            }

            return result;
        }

        public bool DeletePlant(int id)
        {
            bool result = false;

            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {

                try
                {
                    plantdb.LoadOptions = SetDataLoadOptions(TableInUse.Plant);
                    Plant p = plantdb.Plants.First(e => e.id.Equals(id));

                    plantdb.Plants.DeleteOnSubmit(p);
                    plantdb.SubmitChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
            }

            return result;
        }

        public Plant UpdatePlant(int id, string cName, string lName, string imageURL, string description, int sDays)
        {
            Plant result = null;
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                try
                {
                    plantdb.LoadOptions = SetDataLoadOptions(TableInUse.Plant);
                    Plant p = plantdb.Plants.First(e => e.id.Equals(id));

                    p.id = id;
                    p.cname         = cName;
                    p.lname         = lName;
                    p.imgurl        = imageURL;
                    p.description   = description;
                    p.sdays         = sDays;

                    plantdb.SubmitChanges();

                    result = plantdb.Plants.First(e => e.id.Equals(id));
                }
                catch (Exception)
                {
                    result = null;
                }
            }

            return result;
        }

        public List<Plant> GetAllPlants()
        {
            List<Plant> result = new List<Plant>();
            List<Plant> pList = new List<Plant>();
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                plantdb.LoadOptions = SetDataLoadOptions(TableInUse.Plant);
                pList = plantdb.Plants.ToList();
            }
            foreach (Plant p in pList)
            {
                Plant newP = new Plant
                {
                    id = p.id,
                    cname = p.cname,
                    lname = p.lname,
                    description = p.description,
                    imgurl = p.imgurl,
                    sdays = p.sdays
                };
                result.Add(newP);
            }


            return result;
        }

        #endregion

        // ---------------------------   Personal Plant    ----------------------------

        #region Personal Plant

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
            int result = 0;

            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                try
                {
                    
                    plantdb.LoadOptions = SetDataLoadOptions(TableInUse.PersonalPlant);
                    PersonalPlant pplant = new PersonalPlant
                    {
                        pid = plantID,
                        aid = accID,
                        nname = nName,
                        wduration = daysWater,
                        lastwatered = DateTime.Today,
                        nextwatered = DateTime.Today.AddDays(daysWater)
                        
                    };
                    plantdb.PersonalPlants.InsertOnSubmit(pplant);
                    plantdb.SubmitChanges();

                    result = pplant.id;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    result = 0;
                }
            }

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
            List<PersonalPlant> result = new List<PersonalPlant>();
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                plantdb.LoadOptions = SetDataLoadOptions(TableInUse.PersonalPlant);
                result = plantdb.PersonalPlants.ToList();
            }

            return result;
        }

        /// <summary>
        /// Gets a list of all of the personal plants for one account, based on the
        /// entered account ID.
        /// </summary>
        /// <param name="accID">Account ID</param>
        /// <returns>List of Personal Plants for that account</returns>
        public List<PersonalPlant> GetAllAccountPersonalPlants(int accID)
        {
            List<PersonalPlant> result = new List<PersonalPlant>();
            List<PersonalPlant> ppList = new List<PersonalPlant>();
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                plantdb.LoadOptions = SetDataLoadOptions(TableInUse.PersonalPlant);
                ppList = plantdb.PersonalPlants.Where(e => e.aid.Equals(accID)).ToList();
            }
            foreach (PersonalPlant pp in ppList)
            {
                PersonalPlant newPP = new PersonalPlant
                {
                    id = pp.id,
                    aid = pp.aid,
                    pid = pp.pid,
                    nname = pp.nname,
                    lastwatered = pp.lastwatered,
                    nextwatered = pp.nextwatered,
                    wduration = pp.wduration
                };
                result.Add(newPP);
            }

            return result;
        }

        /// <summary>
        /// Find a single personal plant via PersonalPlant ID
        /// </summary>
        /// <param name="ppID">PersonalPlant ID</param>
        /// <returns>Returns the personal plant with the correct PersonalPlantID,
        ///  or it will return null if nothing is find.</returns>
        public PersonalPlant FindPersonalPlant(int ppID)
        {
            PersonalPlant result = null;
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {

                try
                {
                    plantdb.LoadOptions = SetDataLoadOptions(TableInUse.PersonalPlant);
                    PersonalPlant pp = plantdb.PersonalPlants.First(e => e.id.Equals(ppID));
                    result = new PersonalPlant
                    {
                        id = pp.id,
                        aid = pp.aid,
                        pid = pp.pid,
                        nname = pp.nname,
                        wduration = pp.wduration,
                        lastwatered = pp.lastwatered,
                        nextwatered = pp.nextwatered,
                        Plant = pp.Plant
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    result = null;
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

            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {

                try
                {
                    plantdb.LoadOptions = SetDataLoadOptions(TableInUse.PersonalPlant);
                    PersonalPlant pp = plantdb.PersonalPlants.First(e => e.id.Equals(ppID));

                    plantdb.PersonalPlants.DeleteOnSubmit(pp);
                    plantdb.SubmitChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
            }

            return result;
        }

        public bool UpdatePersonalPlant(int ppID, int daysWater, string nName)
        {
            bool result = false;

            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                try
                {
                    plantdb.LoadOptions = SetDataLoadOptions(TableInUse.PersonalPlant);
                    PersonalPlant pp = plantdb.PersonalPlants.First(e => e.id.Equals(ppID));

                    pp.wduration = daysWater;
                    pp.nname = nName;
                    
                    plantdb.SubmitChanges();

                    result = true;

                }
                catch (Exception)
                {
                    result = false;
                }
            }

            return result;

        }


        #endregion


        #region Private Helper Methods
        //Create and return connection string to DB - using the SQLConnectionStringBuilder object
        private static string GetConnectionString()
        {
            SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "PlantR",
                IntegratedSecurity = true
            };

            return conStr.ConnectionString;
        }

        //Create and return a DataLoadOptions object, Takes the name of desired table as input -> see Enum above constructor
        //Specified parameters will load as default when associated with the datacontex object created when connecting to DB (datacontexName.LoadOptions)
        private DataLoadOptions SetDataLoadOptions(TableInUse table)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            TableInUse t = table;

            switch (t)
            {
                case TableInUse.Account:
                    dlo.LoadWith<Account>(A => A.PersonalPlants);
                    break;
                case TableInUse.Plant:
                    dlo.LoadWith<Plant>(A => A.PersonalPlants);
                    break;
                case TableInUse.PersonalPlant:
                    dlo.LoadWith<PersonalPlant>(A => A.Account);
                    dlo.LoadWith<PersonalPlant>(A => A.Plant);
                    break;
            }

            return dlo;
        }
        #endregion
    }
}
