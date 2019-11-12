﻿using PlantRServ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantRServ.DataAccess
{
    class StubADB
    {
        public List<Account> accounts = new List<Account>();
        public StubADB()
        {
            accounts.Add(new Account
            {
                Email = "RustyCougarMama@gmail.com",
                ID = 99,
                Password = "GiveUrBallsATug",
                UserName = "RustyCougarMama",
                PlantList = new List<PersonalPlant>()
            });

            accounts.Add(new Account
            {
                Email = "HungryHungarian@Weeb.com",
                ID = 777,
                Password = "OmaeWaMouShindeiru",
                UserName = "NaniSempai",
                PlantList = new List<PersonalPlant>()
            });

            accounts.Add(new Account
            {
                Email = "WesleySnipes@Real.com",
                ID = 69,
                Password = "ImABetterSamJackson",
                UserName = "KickboxingVampire",
                PlantList = new List<PersonalPlant>()
            });
        }
    }
}
