using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PlantRServ.Model;
using PlantRServ.DataAccess;
using System.Data.SqlClient;

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

        public Account FindAccount(int accID)
        {
            using (plantdb = new LinQtoSQLDataContext(GetConnectionString()))
            {

                Account result = plantdb.Accounts.First(e => e.id.Equals(accID));

                Account acc = new Account
                {
                    id = result.id,
                    username = result.username,
                    email = result.email,
                    password = result.password

                };

                return acc;
            }
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
