using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace am108217MIS4200.Models
{
    public class Procedure
    {
        public int procedureID { get; set; }
        public string procedureType { get; set; }
        public DateTime procedureDate { get; set; }
        public decimal procedureCost { get; set; }

        
        public ICollection<Vet> Vet { get; set; }

    }
}