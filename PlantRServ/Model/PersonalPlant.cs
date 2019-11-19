using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PlantRServ.Model
{
    [DataContract]
    public class PersonalPlant : Plant
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime LastWatered { get; set; }
        [DataMember]
        public DateTime NextWatered { get; set; }
        [DataMember]
        public string NName { get; set; }
        [DataMember]
        public int WDuration { get; set; }
        [DataMember]
        public int AId { get; set; }


    }
}
 