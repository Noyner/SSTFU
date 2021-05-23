using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSTFU_V2.Models
{
    public class EUser
    {
        public string Token { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string fatherName { get; set; }
        public bool banFlag { get; set; }
        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
