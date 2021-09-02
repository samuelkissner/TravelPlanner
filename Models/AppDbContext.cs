using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelPlanner.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(

                new Trip() { ID = 1, Name = "Tim's Wedding", Description = "Tim is having a destination wedding in Findland at the end of the year.", DepartureDate = new DateTime(12 / 05 / 2021), ReturnDate = new DateTime(12 / 11 / 2021), Budget = 5000 },
                new Trip() { ID = 2, Name = "Halloween Party", Description = "Attending a halloween-themed costume party at the company branch in Austin.", DepartureDate = new DateTime(10 / 28 / 2021), ReturnDate = new DateTime(11 / 01 / 2021), Budget = 600 },
                new Trip() { ID = 3, Name = "Carribean Cruise", Description = "Two week, all-inclusive.", DepartureDate = new DateTime(07 / 01 / 2022), ReturnDate = new DateTime(07 / 14 / 2022), Budget = 2500 }



                );
        }
    }
}
