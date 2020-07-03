﻿// <auto-generated />
using System;
using AuthenticationMicroservice.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuthenticationMicroservice.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthenticationMicroservice.Database.UserLogins", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Career")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Names")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPCCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("DomainModels.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Career")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Names")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPCCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Career = "Ingeniería de Sistemas",
                            CreationDate = new DateTime(2020, 7, 3, 12, 31, 20, 12, DateTimeKind.Local).AddTicks(7663),
                            CreationUser = "ADMIN01",
                            Email = "U201524462@upc.edu.pe",
                            FirstName = "Acero",
                            LastName = "Soria",
                            Modality = "EPE",
                            Names = "Dany Daniel",
                            Password = "Password1",
                            UPCCode = "U201524462"
                        },
                        new
                        {
                            UserId = 2,
                            Career = "Ingeniería de Sistemas",
                            CreationDate = new DateTime(2020, 7, 3, 12, 31, 20, 12, DateTimeKind.Local).AddTicks(8162),
                            CreationUser = "ADMIN01",
                            Email = "U201524476@upc.edu.pe",
                            FirstName = "Canales",
                            LastName = "Tacilla",
                            Modality = "EPE",
                            Names = "Luis Brayan",
                            Password = "Password2",
                            UPCCode = "U201524476"
                        },
                        new
                        {
                            UserId = 3,
                            Career = "",
                            CreationDate = new DateTime(2020, 7, 3, 12, 31, 20, 12, DateTimeKind.Local).AddTicks(8172),
                            CreationUser = "ADMIN01",
                            Email = "b20200601@upc.edu.pe",
                            FirstName = "Mármol",
                            LastName = "Coloma",
                            Modality = "",
                            Names = "Roberto André",
                            Password = "Password3",
                            UPCCode = "b20200601"
                        },
                        new
                        {
                            UserId = 4,
                            Career = "",
                            CreationDate = new DateTime(2020, 7, 3, 12, 31, 20, 12, DateTimeKind.Local).AddTicks(8175),
                            CreationUser = "ADMIN01",
                            Email = "s20200601@upc.edu.pe",
                            FirstName = "Chumacero",
                            LastName = "Cruz",
                            Modality = "",
                            Names = "Luigui",
                            Password = "Password4",
                            UPCCode = "s20200601"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
