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
        //public static string constring = System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString();
        public LinQtoSQLDataContext plantdb;
        public AccountRepository()
        {
        }

        public Account AddAccount(string userName, string email, string password)
        {
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<Account>(A => A.PersonalPlants);
                plantdb.LoadOptions = dlo;
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
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<Account>(A => A.PersonalPlants);
                plantdb.LoadOptions = dlo;
                Account result = plantdb.Accounts.First(e => e.email.Equals(email));

/*                Account acc = new Account
                {
                    id = result.id,
                    username = result.username,
                    email = result.email,
                    password = result.password,
                    PersonalPlants = result.PersonalPlants

                };
*/
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
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<Account>(A => A.PersonalPlants);
                plantdb.LoadOptions = dlo;
                result = plantdb.Accounts.ToList();
            }

            return result;
        }

        public bool AddPlant(string cName, string lName, string imageURL, string description, int sDays)
        {
            bool result = false;

            using(plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {

                try
                {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<Account>(A => A.PersonalPlants);
                plantdb.LoadOptions = dlo;
                    Plant plant = new Plant
                    {
                        cname = cName,
                        lname = lName,
                        imgurl = imageURL,
                        description = description,
                        sdays = sDays
                    };
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return result;
        }


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


    }
}
