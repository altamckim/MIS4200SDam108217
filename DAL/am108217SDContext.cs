using am108217MIS4200.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace am108217MIS4200.DAL
{
    public class am108217SDContext : DbContext 
    {
        public am108217SDContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Vet> Vet { get; set; }
        public DbSet<Procedure> Procedure { get; set; }
        
    }
}