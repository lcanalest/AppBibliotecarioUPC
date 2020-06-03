using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationMicroservice.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasKey(e => new { e.UserId });

            modelBuilder
                .Entity<User>()
                .HasData(
                new User
                {
                    UserId = 1,
                    UPCCode = "U201524462",
                    Password = "Password1",
                    FirstName = "Acero",
                    LastName = "Soria",
                    Names = "Dany Daniel",
                    Email = "U201524462@upc.edu.pe",
                    Phone = "999888555",
                    Career = "Ingeniería de Sistemas - EPE",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new User
                {
                    UserId = 2,
                    UPCCode = "U201524476",
                    Password = "Password2",
                    FirstName = "Canales",
                    LastName = "Tacilla",
                    Names = "Luis Brayan",
                    Email = "U201524476@upc.edu.pe",
                    Phone = "999555888",
                    Career = "Ingeniería de Sistemas - EPE",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                }
                );
        }
    }
}
