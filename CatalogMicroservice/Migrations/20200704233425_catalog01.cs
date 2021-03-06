﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogMicroservice.Migrations
{
    public partial class catalog01 : Migration
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
                    BUserCode = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Names = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackofficeUsers", x => x.BUserCode);
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
                name: "ServiceStatus",
                columns: table => new
                {
                    ServiceStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceStatus", x => x.ServiceStatusId);
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
                    BUserCode = table.Column<string>(nullable: false),
                    CampusId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiblioSchedule", x => new { x.BUserCode, x.CampusId, x.StartTime, x.EndTime });
                    table.ForeignKey(
                        name: "FK_BiblioSchedule_BackofficeUsers_BUserCode",
                        column: x => x.BUserCode,
                        principalTable: "BackofficeUsers",
                        principalColumn: "BUserCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiblioSchedule_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    BUserCode = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.BUserCode, x.RoleId });
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
                    PositiveCalification = table.Column<int>(nullable: false),
                    NegativeCalification = table.Column<int>(nullable: false),
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
                    RequestDetail = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileContent = table.Column<byte[]>(nullable: true),
                    ServiceStatusId = table.Column<int>(nullable: false),
                    BUserCode = table.Column<string>(nullable: true),
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
                        name: "FK_ServiceRequests_BackofficeUsers_BUserCode",
                        column: x => x.BUserCode,
                        principalTable: "BackofficeUsers",
                        principalColumn: "BUserCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "CampusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_ServiceStatus_ServiceStatusId",
                        column: x => x.ServiceStatusId,
                        principalTable: "ServiceStatus",
                        principalColumn: "ServiceStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequestDetail",
                columns: table => new
                {
                    ServiceRequestId = table.Column<int>(nullable: false),
                    ServiceRequestSequence = table.Column<int>(nullable: false),
                    ServiceStatusId = table.Column<int>(nullable: false),
                    AttentionDetail = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestDetail", x => new { x.ServiceRequestId, x.ServiceRequestSequence });
                    table.ForeignKey(
                        name: "FK_ServiceRequestDetail_ServiceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "ServiceRequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequestDetail_ServiceStatus_ServiceStatusId",
                        column: x => x.ServiceStatusId,
                        principalTable: "ServiceStatus",
                        principalColumn: "ServiceStatusId");
                });

            migrationBuilder.InsertData(
                table: "AttentionModes",
                columns: new[] { "AttentionModeId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 4, 18, 34, 25, 124, DateTimeKind.Local).AddTicks(3384), "ADMIN01", "Presencial" },
                    { 2, new DateTime(2020, 7, 4, 18, 34, 25, 124, DateTimeKind.Local).AddTicks(4280), "ADMIN01", "Virtual" }
                });

            migrationBuilder.InsertData(
                table: "BackofficeUsers",
                columns: new[] { "BUserCode", "CreationDate", "CreationUser", "Email", "FirstName", "LastName", "Names" },
                values: new object[,]
                {
                    { "b20200601", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(5581), "ADMIN01", "b20200601@upc.edu.pe", "Mármol", "Coloma", "Roberto André" },
                    { "s20200601", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(6412), "ADMIN01", "s20200601@upc.edu.pe", "Chumacero", "Cruz", "Luigui" }
                });

            migrationBuilder.InsertData(
                table: "Campus",
                columns: new[] { "CampusId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 4, 18, 34, 25, 124, DateTimeKind.Local).AddTicks(5729), "ADMIN01", "Campus Monterrico" },
                    { 2, new DateTime(2020, 7, 4, 18, 34, 25, 124, DateTimeKind.Local).AddTicks(6578), "ADMIN01", "Campus Villa" },
                    { 3, new DateTime(2020, 7, 4, 18, 34, 25, 124, DateTimeKind.Local).AddTicks(6596), "ADMIN01", "Campus San Miguel" },
                    { 4, new DateTime(2020, 7, 4, 18, 34, 25, 124, DateTimeKind.Local).AddTicks(6597), "ADMIN01", "Campus San Isidro" },
                    { 5, new DateTime(2020, 7, 4, 18, 34, 25, 124, DateTimeKind.Local).AddTicks(6598), "ADMIN01", "Campus Virtual" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(7724), "ADMIN01", "Bibliotecólogo" },
                    { 2, new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(8528), "ADMIN01", "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "ServiceStatus",
                columns: new[] { "ServiceStatusId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 4, new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(3182), "ADMIN01", "Cerrada" },
                    { 3, new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(3181), "ADMIN01", "En atención" },
                    { 1, new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(2347), "ADMIN01", "Registrada" },
                    { 2, new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(3163), "ADMIN01", "Asignada" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 7, new DateTime(2020, 7, 4, 18, 34, 25, 123, DateTimeKind.Local).AddTicks(853), "ADMIN01", "Análisis bibliométrico" },
                    { 1, new DateTime(2020, 7, 4, 18, 34, 25, 122, DateTimeKind.Local).AddTicks(1388), "ADMIN01", "Normas de citación y referencias" },
                    { 2, new DateTime(2020, 7, 4, 18, 34, 25, 123, DateTimeKind.Local).AddTicks(813), "ADMIN01", "Test de Similitud" },
                    { 3, new DateTime(2020, 7, 4, 18, 34, 25, 123, DateTimeKind.Local).AddTicks(848), "ADMIN01", "Búsqueda de información" },
                    { 4, new DateTime(2020, 7, 4, 18, 34, 25, 123, DateTimeKind.Local).AddTicks(850), "ADMIN01", "Gestores de referencias (Mendeley)" },
                    { 5, new DateTime(2020, 7, 4, 18, 34, 25, 123, DateTimeKind.Local).AddTicks(851), "ADMIN01", "Búsqueda de artículos científicos" },
                    { 6, new DateTime(2020, 7, 4, 18, 34, 25, 123, DateTimeKind.Local).AddTicks(852), "ADMIN01", "Plantilla de Tesis y Trabajo de investigación" },
                    { 8, new DateTime(2020, 7, 4, 18, 34, 25, 123, DateTimeKind.Local).AddTicks(855), "ADMIN01", "Asesoría" }
                });

            migrationBuilder.InsertData(
                table: "BiblioSchedule",
                columns: new[] { "BUserCode", "CampusId", "StartTime", "EndTime", "CreationDate", "CreationUser" },
                values: new object[] { "b20200601", 1, new DateTime(2020, 7, 4, 18, 34, 25, 126, DateTimeKind.Local).AddTicks(2008), new DateTime(2020, 7, 4, 22, 34, 25, 126, DateTimeKind.Local).AddTicks(2433), new DateTime(2020, 7, 4, 18, 34, 25, 126, DateTimeKind.Local).AddTicks(3018), "ADMIN01" });

            migrationBuilder.InsertData(
                table: "KnowledgeBase",
                columns: new[] { "QuestionId", "Answer", "CreationDate", "CreationUser", "InquiriesQuantity", "NegativeCalification", "Pinned", "PositiveCalification", "Question", "ServiceTypeId" },
                values: new object[,]
                {
                    { 1, "Respuesta para citación de figuras y tablas", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(110), "ADMIN01", 0, 0, 0, 0, "¿Cómo citar figuras o tablas?", 1 },
                    { 2, "Respuesta para el parafraseo", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(970), "ADMIN01", 0, 0, 0, 0, "¿Cómo es el parafraseo?", 1 },
                    { 3, "Respuesta para las notas a pie de página", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(988), "ADMIN01", 0, 0, 0, 0, "¿Qué son las notas a pie de página? ¿Cómo se usan?", 1 },
                    { 4, "Respuesta para reporte de coincidencias de Safe Assign", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(990), "ADMIN01", 0, 0, 0, 0, "Reporte de coincidencias de Safe Assign", 2 },
                    { 5, "Respuesta para búsqueda por temas", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(991), "ADMIN01", 0, 0, 0, 0, "Búsqueda por temas", 3 },
                    { 6, "Respuesta para búsqueda de revistas en cuartiles", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(993), "ADMIN01", 0, 0, 0, 0, "Búsqueda de revistas en cuartiles", 3 },
                    { 7, "Respuesta para revistas indexadas por disciplina", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(995), "ADMIN01", 0, 0, 0, 0, "Revistas indexadas por disciplina", 3 },
                    { 8, "Respuesta para instalar import to Mendeley", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(996), "ADMIN01", 0, 0, 0, 0, "¿Cómo instalar import to Mendeley?", 4 },
                    { 9, "Respuesta para instalar el plugin de word en Mendeley", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(998), "ADMIN01", 0, 0, 0, 0, "¿Cómo instalar el plugin de word en Mendeley?", 4 },
                    { 10, "Respuesta para búsqueda de artículos científicos", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(999), "ADMIN01", 0, 0, 0, 0, "¿Dónde puedo buscar artículos científicos?", 5 },
                    { 11, "Respuesta para ruta de plantillas de acuerdo a la carrera", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(1000), "ADMIN01", 0, 0, 0, 0, "¿Dónde puedo encontrar plantillas de acuerdo a mi carrera?", 6 },
                    { 12, "Respuesta para análisis bibliométrico?", new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(1002), "ADMIN01", 0, 0, 0, 0, "¿En qué se basa el análisis bibliométrico?", 7 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "BUserCode", "RoleId", "CreationDate", "CreationUser" },
                values: new object[,]
                {
                    { "b20200601", 1, new DateTime(2020, 7, 4, 18, 34, 25, 125, DateTimeKind.Local).AddTicks(9848), "ADMIN01" },
                    { "s20200601", 2, new DateTime(2020, 7, 4, 18, 34, 25, 126, DateTimeKind.Local).AddTicks(654), "ADMIN01" }
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
                name: "IX_ServiceRequestDetail_ServiceStatusId",
                table: "ServiceRequestDetail",
                column: "ServiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_AttentionModeId",
                table: "ServiceRequests",
                column: "AttentionModeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_BUserCode",
                table: "ServiceRequests",
                column: "BUserCode");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_CampusId",
                table: "ServiceRequests",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ServiceStatusId",
                table: "ServiceRequests",
                column: "ServiceStatusId");

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
                name: "ServiceRequestDetail");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AttentionModes");

            migrationBuilder.DropTable(
                name: "BackofficeUsers");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "ServiceStatus");

            migrationBuilder.DropTable(
                name: "ServiceTypes");
        }
    }
}
