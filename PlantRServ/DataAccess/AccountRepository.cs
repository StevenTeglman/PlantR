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

        // ------------------------------   ACCOUNT    -------------------------------

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
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                plantdb.LoadOptions = SetDataLoadOptions(TableInUse.Plant);
                result = plantdb.Plants.ToList();
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
