using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogMicroservice.Migrations
{
    public partial class Catalog01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttentionModes",
                columns: table => new
                {
                    AttentionModeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttentionModes", x => x.AttentionModeId);
                });

            migrationBuilder.CreateTable(
                name: "BackofficeUsers",
                columns: table => new
                {
                    UPCCode = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Names = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackofficeUsers", x => x.UPCCode);
                });

            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    CampusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.CampusId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BiblioSchedule",
                columns: table => new
                {
                    UPCCode = table.Column<string>(nullable: false),
                    CampusId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiblioSchedule", x => new { x.UPCCode, x.CampusId });
                    table.ForeignKey(
                        name: "FK_BiblioSchedule_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiblioSchedule_BackofficeUsers_UPCCode",
                        column: x => x.UPCCode,
                        principalTable: "BackofficeUsers",
                        principalColumn: "UPCCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UPCCode = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UPCCode, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeBase",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeId = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    InquiriesQuantity = table.Column<int>(nullable: false),
                    Pinned = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeBase", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_KnowledgeBase_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    ServiceRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UPCCode = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Names = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Career = table.Column<string>(nullable: true),
                    Modality = table.Column<string>(nullable: true),
                    ServiceTypeId = table.Column<int>(nullable: false),
                    AttentionModeId = table.Column<int>(nullable: false),
                    CampusId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.ServiceRequestId);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_AttentionModes_AttentionModeId",
                        column: x => x.AttentionModeId,
                        principalTable: "AttentionModes",
                        principalColumn: "AttentionModeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AttentionModes",
                columns: new[] { "AttentionModeId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 23, 17, 12, 42, 464, DateTimeKind.Local).AddTicks(4374), "ADMIN01", "Presencial" },
                    { 2, new DateTime(2020, 6, 23, 17, 12, 42, 464, DateTimeKind.Local).AddTicks(5281), "ADMIN01", "Virtual" }
                });

            migrationBuilder.InsertData(
                table: "BackofficeUsers",
                columns: new[] { "UPCCode", "CreationDate", "CreationUser", "Email", "FirstName", "LastName", "Names" },
                values: new object[,]
                {
                    { "b20200601", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(3592), "ADMIN01", "b20200601@upc.edu.pe", "Mármol", "Coloma", "Roberto André" },
                    { "s20200601", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(4552), "ADMIN01", "s20200601@upc.edu.pe", "Chumacero", "Cruz", "Luigui" }
                });

            migrationBuilder.InsertData(
                table: "Campus",
                columns: new[] { "CampusId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 23, 17, 12, 42, 464, DateTimeKind.Local).AddTicks(6659), "ADMIN01", "Campus Monterrico" },
                    { 2, new DateTime(2020, 6, 23, 17, 12, 42, 464, DateTimeKind.Local).AddTicks(7494), "ADMIN01", "Campus Villa" },
                    { 3, new DateTime(2020, 6, 23, 17, 12, 42, 464, DateTimeKind.Local).AddTicks(7515), "ADMIN01", "Campus San Miguel" },
                    { 4, new DateTime(2020, 6, 23, 17, 12, 42, 464, DateTimeKind.Local).AddTicks(7517), "ADMIN01", "Campus San Isidro" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(7419), "ADMIN01", "Supervisor" },
                    { 1, new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(6553), "ADMIN01", "Bibliotecólogo" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 23, 17, 12, 42, 462, DateTimeKind.Local).AddTicks(4046), "ADMIN01", "Normas de citación y referencias" },
                    { 2, new DateTime(2020, 6, 23, 17, 12, 42, 463, DateTimeKind.Local).AddTicks(2616), "ADMIN01", "Test de Similitud" },
                    { 3, new DateTime(2020, 6, 23, 17, 12, 42, 463, DateTimeKind.Local).AddTicks(2645), "ADMIN01", "Búsqueda de información" },
                    { 4, new DateTime(2020, 6, 23, 17, 12, 42, 463, DateTimeKind.Local).AddTicks(2647), "ADMIN01", "Gestores de referencias (Mendeley)" },
                    { 5, new DateTime(2020, 6, 23, 17, 12, 42, 463, DateTimeKind.Local).AddTicks(2685), "ADMIN01", "Búsqueda de artículos científicos" },
                    { 6, new DateTime(2020, 6, 23, 17, 12, 42, 463, DateTimeKind.Local).AddTicks(2686), "ADMIN01", "Plantilla de Tesis y Trabajo de investigación" },
                    { 7, new DateTime(2020, 6, 23, 17, 12, 42, 463, DateTimeKind.Local).AddTicks(2688), "ADMIN01", "Análisis bibliométrico" }
                });

            migrationBuilder.InsertData(
                table: "BiblioSchedule",
                columns: new[] { "UPCCode", "CampusId", "CreationDate", "CreationUser", "EndTime", "StartTime" },
                values: new object[] { "b20200601", 1, new DateTime(2020, 6, 23, 17, 12, 42, 466, DateTimeKind.Local).AddTicks(1897), "ADMIN01", new DateTime(2020, 6, 23, 21, 12, 42, 466, DateTimeKind.Local).AddTicks(1375), new DateTime(2020, 6, 23, 17, 12, 42, 466, DateTimeKind.Local).AddTicks(968) });

            migrationBuilder.InsertData(
                table: "KnowledgeBase",
                columns: new[] { "QuestionId", "Answer", "CreationDate", "CreationUser", "InquiriesQuantity", "Pinned", "Question", "ServiceTypeId" },
                values: new object[,]
                {
                    { 1, "Respuesta para citación de figuras y tablas", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(302), "ADMIN01", 0, 0, "¿Cómo citar figuras o tablas?", 1 },
                    { 2, "Respuesta para el parafraseo", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1156), "ADMIN01", 0, 0, "¿Cómo es el parafraseo?", 1 },
                    { 3, "Respuesta para las notas a pie de página", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1174), "ADMIN01", 0, 0, "¿Qué son las notas a pie de página? ¿Cómo se usan?", 1 },
                    { 4, "Respuesta para reporte de coincidencias de Safe Assign", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1176), "ADMIN01", 0, 0, "Reporte de coincidencias de Safe Assign", 2 },
                    { 5, "Respuesta para búsqueda por temas", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1177), "ADMIN01", 0, 0, "Búsqueda por temas", 3 },
                    { 6, "Respuesta para búsqueda de revistas en cuartiles", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1178), "ADMIN01", 0, 0, "Búsqueda de revistas en cuartiles", 3 },
                    { 7, "Respuesta para revistas indexadas por disciplina", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1180), "ADMIN01", 0, 0, "Revistas indexadas por disciplina", 3 },
                    { 8, "Respuesta para instalar import to Mendeley", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1182), "ADMIN01", 0, 0, "¿Cómo instalar import to Mendeley?", 4 },
                    { 9, "Respuesta para instalar el plugin de word en Mendeley", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1187), "ADMIN01", 0, 0, "¿Cómo instalar el plugin de word en Mendeley?", 4 },
                    { 10, "Respuesta para búsqueda de artículos científicos", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1189), "ADMIN01", 0, 0, "¿Dónde puedo buscar artículos científicos?", 5 },
                    { 11, "Respuesta para ruta de plantillas de acuerdo a la carrera", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1190), "ADMIN01", 0, 0, "¿Dónde puedo encontrar plantillas de acuerdo a mi carrera?", 6 },
                    { 12, "Respuesta para análisis bibliométrico?", new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(1192), "ADMIN01", 0, 0, "¿En qué se basa el análisis bibliométrico?", 7 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UPCCode", "RoleId", "CreationDate", "CreationUser" },
                values: new object[,]
                {
                    { "b20200601", 1, new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(8830), "ADMIN01" },
                    { "s20200601", 2, new DateTime(2020, 6, 23, 17, 12, 42, 465, DateTimeKind.Local).AddTicks(9641), "ADMIN01" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiblioSchedule_CampusId",
                table: "BiblioSchedule",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeBase_ServiceTypeId",
                table: "KnowledgeBase",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_AttentionModeId",
                table: "ServiceRequests",
                column: "AttentionModeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_CampusId",
                table: "ServiceRequests",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ServiceTypeId",
                table: "ServiceRequests",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiblioSchedule");

            migrationBuilder.DropTable(
                name: "KnowledgeBase");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "BackofficeUsers");

            migrationBuilder.DropTable(
                name: "AttentionModes");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
