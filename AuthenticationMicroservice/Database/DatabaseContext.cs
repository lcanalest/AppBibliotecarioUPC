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
        public DbSet<UserLogins> UserLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasKey(e => new { e.UserId });

            modelBuilder.Entity<UserLogins>()
                .HasKey(ul => new { ul.LoginId });

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
                    Career = "Ingeniería de Sistemas",
                    Modality = "EPE",
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
                    Career = "Ingeniería de Sistemas",
                    Modality = "EPE",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new User
                {
                    UserId = 3,
                    UPCCode = "b20200601",
                    Password = "Password3",
                    FirstName = "Mármol",
                    LastName = "Coloma",
                    Names = "Roberto André",
                    Email = "b20200601@upc.edu.pe",
                    Career = "",
                    Modality = "",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new User
                {
                    UserId = 4,
                    UPCCode = "s20200601",
                    Password = "Password4",
                    FirstName = "Chumacero",
                    LastName = "Cruz",
                    Names = "Luigui",
                    Email = "s20200601@upc.edu.pe",
                    Career = "",
                    Modality = "",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                }
                );
        }
    }
}
