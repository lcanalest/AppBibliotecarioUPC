using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationMicroservice.Migrations
{
    public partial class User01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UPCCode = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Names = table.Column<string>(nullable: true),
                    Career = table.Column<string>(nullable: true),
                    Modality = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.LoginId);
                });

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
                    Career = table.Column<string>(nullable: true),
                    Modality = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Career", "CreationDate", "CreationUser", "Email", "FirstName", "LastName", "Modality", "Names", "Password", "UPCCode" },
                values: new object[,]
                {
                    { 1, "Ingeniería de Sistemas", new DateTime(2020, 7, 5, 16, 54, 31, 834, DateTimeKind.Local).AddTicks(3188), "ADMIN01", "U201524462@upc.edu.pe", "Acero", "Soria", "EPE", "Dany Daniel", "Password1", "U201524462" },
                    { 2, "Ingeniería de Sistemas", new DateTime(2020, 7, 5, 16, 54, 31, 834, DateTimeKind.Local).AddTicks(4965), "ADMIN01", "U201524476@upc.edu.pe", "Canales", "Tacilla", "EPE", "Luis Brayan", "Password2", "U201524476" },
                    { 3, "", new DateTime(2020, 7, 5, 16, 54, 31, 834, DateTimeKind.Local).AddTicks(4981), "ADMIN01", "b20200601@upc.edu.pe", "Mármol", "Coloma", "", "Roberto André", "Password3", "b20200601" },
                    { 4, "", new DateTime(2020, 7, 5, 16, 54, 31, 834, DateTimeKind.Local).AddTicks(4987), "ADMIN01", "s20200601@upc.edu.pe", "Chumacero", "Cruz", "", "Luigui", "Password4", "s20200601" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
