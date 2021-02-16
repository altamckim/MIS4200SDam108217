using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace am108217MIS4200.Models
{
    public class Vet
    {
        public int vetID { get; set; }
        public string vetFirstName { get; set; }
        public string vetLastName { get; set; }
        public string vetAddress { get; set; }
        public string vetEmail { get; set; }
        public string vetPhone { get; set; }

        public int ownerID { get; set; }
        public virtual Owner owner { get; set; }

        
       



    }
}