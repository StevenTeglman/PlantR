﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PlantRServ.Model
{
    [DataContract]
    public class Plant
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CName { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public string ImageURL { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int SDays { get; set; }

    }
}
