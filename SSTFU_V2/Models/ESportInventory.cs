using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSTFU_V2.Models
{
    public class ESportInventory
    {
        public int Id { get; set; }
        public ESportInventoryType Type { get; set; }
        public string Description { get; set; }
        public int TypeOfStorage { get; set; }//0=ESportObj 1=ERentalPlace

        public ERentPlace RentPlace { get; set; }
        // /\
        // or
        // \/
        public ESportObject SportObject { get; set; }

        public int MaxMinRentalUnitsType { get; set; }//0=days 1=hours
        public int MinRentalTime { get; set; }
        public int MaxRentalTime { get; set; }
    }
}
