using PlantRServ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantRMVC2.Models
{
    public class UserHomeModel
    {

        public IEnumerable<PersonalPlant> Plants { get; private set; }

        public UserHomeModel(IEnumerable<PersonalPlant> plants)
        {
            Plants = plants;
        }
    }
}