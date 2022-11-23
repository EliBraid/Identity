using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public class DataDbcontext: DbContext
    {
        public DbSet<House> Houses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;database=Test;trusted_connection=true;trustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().Property(h => h.Owner).IsConcurrencyToken();
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    Id = 1,
                    Name= "1-501-1"
                },
                new House
                {
                    Id = 2,
                    Name = "1-501-2"
                }
                );
        }
    }
}
