using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace am108217MIS4200.Models
{
    public class Pet
    {
        public int petID { get; set; }
        public string petName { get; set; }
        public string petBreed { get; set; }
        public int petAge { get; set; }
        public string petColor { get; set; } 
        public DateTime adoptionDate { get; set; }

        public int ownerID { get; set; }
        public virtual Owner owner { get; set; }

        public ICollection<Vet> Vet { get; set; }
    }
}