using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace am108217MIS4200.Models
{
    public class Owner
    {
        public int ownerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string fullName 
        {
            get
            {
                return lastName + ", " + firstName; 
            }
    }
        public ICollection<Pet> Pet { get; set; }


    }
}