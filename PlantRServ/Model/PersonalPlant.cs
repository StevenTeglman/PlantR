using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int PId { get; set; }
        [DataMember]
        public int AId { get; set; }
        [DisplayName("Plant Nick Name")]
        [DataMember]
        public string NName { get; set; }
        [DataMember]
        public DateTime LastWatered { get; set; }
        [DataMember]
        public DateTime NextWatered { get; set; }
        [DisplayName("Days Between Watering")]
        [DataMember]
        public int WDuration { get; set; }
        [DataMember]
        public Account account { get; set; }
        [DisplayName("Type of Plant")]
        [DataMember]
        public Plant plant { get; set; }




    }
}
 