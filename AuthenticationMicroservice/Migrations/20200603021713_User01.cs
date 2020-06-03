using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationMicroservice.Migrations
{
    public partial class User01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UPCCode = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Names = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Career = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Career", "CreationDate", "CreationUser", "Email", "FirstName", "LastName", "Names", "Password", "Phone", "UPCCode" },
                values: new object[] { 1, "Ingeniería de Sistemas - EPE", new DateTime(2020, 6, 2, 21, 17, 13, 202, DateTimeKind.Local).AddTicks(3384), "ADMIN01", "U201524462@upc.edu.pe", "Acero", "Soria", "Dany Daniel", "Password1", "999888555", "U201524462" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Career", "CreationDate", "CreationUser", "Email", "FirstName", "LastName", "Names", "Password", "Phone", "UPCCode" },
                values: new object[] { 2, "Ingeniería de Sistemas - EPE", new DateTime(2020, 6, 2, 21, 17, 13, 202, DateTimeKind.Local).AddTicks(3875), "ADMIN01", "U201524476@upc.edu.pe", "Canales", "Tacilla", "Luis Brayan", "Password2", "999555888", "U201524476" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
