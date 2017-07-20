using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess
{
    public class DystopianRepository : DbContext
    {
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Squadron> Squadrons { get; set; }
        public DbSet<SquadronEntry> SquadronEntries { get; set; }

        public DystopianRepository(): base()
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Fluent API mapping here
            base.OnModelCreating(modelBuilder);
        }
    }
}
