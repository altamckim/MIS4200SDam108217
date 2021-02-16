namespace am108217MIS4200.Migrations.am108217SDContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<am108217MIS4200.DAL.am108217SDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\am108217SDContext";
            ContextKey = "am108217MIS4200.DAL.am108217SDContext";
        }

        protected override void Seed(am108217MIS4200.DAL.am108217SDContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
