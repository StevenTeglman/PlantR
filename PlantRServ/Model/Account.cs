using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PlantRServ.Model
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public List<PersonalPlant> PlantList { get; set; }

    }
}