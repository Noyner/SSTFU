using SSTFU_V2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSTFU_V2.Models.ViewModels
{
    public class HomeViewModel:ViewModelBase
    {
        //public string usersCount { get; set; }
        public List<ESportObject> SportObjects { get; set; }
        public List<ERentPlace> RentPlaces { get; set; }

    }
}
