using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantrMVC.Models
{
    public class Account
    {
        public int AccountID { get; set; }

        public String UserName { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public Account() { }

        public Account(int accountID, string userName, string email, string password)
        {
            AccountID = accountID;
            UserName = userName;
            Email = email;
            Password = password;


        }
    }
}