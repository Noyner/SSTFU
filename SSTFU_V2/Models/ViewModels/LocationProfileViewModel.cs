using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSTFU_V2.Models.ViewModels
{
    public class LocationProfileViewModel
    {
        public int TypeMarker { get; set; }//0=sport object 1=rental place
        public ESportObject sportObject { get; set; }
        public ERentPlace rentPlace { get; set; }

        public Dictionary<int, string> MinMaxUnitTypeToString = new Dictionary<int, string>()
        {
            {0,"Дней" },
            {1,"Часов" }
        };

        public string FreeStatus => sportObject.FreeStatus == true ? "Свободен" : "Занят";
    }
}
