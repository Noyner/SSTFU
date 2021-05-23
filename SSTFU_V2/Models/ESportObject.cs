using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSTFU_V2.Models
{
    public class ESportObject
    {
        public int Id { get; set; }
       public string Coords { get; set; }
      public  string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ImageLink { get; set; }
        public List<ESportInventory> AvailableInventory { get; set; }
        public EObjectCategory ObjectCategory { get; set; }
        public bool FreeStatus { get; set; }
        public int MaxPerson { get; set; }
        public int MaxMinRentalUnitsType { get; set; }//0=days 1=hours
        public int MinRentalTime { get; set; }
        public int MaxRentalTime { get; set; }


    }
}
