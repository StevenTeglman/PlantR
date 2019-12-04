
using PlantRServ.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public class PersonalPlantModel
    {
        [DisplayName("Your Plant's Nick Name")]
        public string NName { get; set; }
        [DisplayName("Type of Plant : Suggest Watering Days")]
        public string PId { get; set; }
        [DisplayName("Days Between Watering")]
        public int WDuration { get; set; }
    }
}