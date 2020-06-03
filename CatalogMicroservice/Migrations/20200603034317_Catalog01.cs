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

            migrationBuilder.InsertData(
                table: "AttentionModes",
                columns: new[] { "AttentionModeId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 2, 22, 43, 16, 885, DateTimeKind.Local).AddTicks(4421), "ADMIN01", "Presencial" },
                    { 2, new DateTime(2020, 6, 2, 22, 43, 16, 885, DateTimeKind.Local).AddTicks(5356), "ADMIN01", "Virtual" }
                });

            migrationBuilder.InsertData(
                table: "Campus",
                columns: new[] { "CampusId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 2, 22, 43, 16, 885, DateTimeKind.Local).AddTicks(6807), "ADMIN01", "Campus Monterrico" },
                    { 2, new DateTime(2020, 6, 2, 22, 43, 16, 885, DateTimeKind.Local).AddTicks(7660), "ADMIN01", "Campus Villa" },
                    { 3, new DateTime(2020, 6, 2, 22, 43, 16, 885, DateTimeKind.Local).AddTicks(7678), "ADMIN01", "Campus San Miguel" },
                    { 4, new DateTime(2020, 6, 2, 22, 43, 16, 885, DateTimeKind.Local).AddTicks(7679), "ADMIN01", "Campus San Isidro" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "CreationDate", "CreationUser", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 2, 22, 43, 16, 883, DateTimeKind.Local).AddTicks(2833), "ADMIN01", "Normas de citación y referencias" },
                    { 2, new DateTime(2020, 6, 2, 22, 43, 16, 884, DateTimeKind.Local).AddTicks(1525), "ADMIN01", "Test de Similitud" },
                    { 3, new DateTime(2020, 6, 2, 22, 43, 16, 884, DateTimeKind.Local).AddTicks(1553), "ADMIN01", "Búsqueda de información" },
                    { 4, new DateTime(2020, 6, 2, 22, 43, 16, 884, DateTimeKind.Local).AddTicks(1555), "ADMIN01", "Gestores de referencias (Mendeley)" },
                    { 5, new DateTime(2020, 6, 2, 22, 43, 16, 884, DateTimeKind.Local).AddTicks(1556), "ADMIN01", "Búsqueda de artículos científicos" },
                    { 6, new DateTime(2020, 6, 2, 22, 43, 16, 884, DateTimeKind.Local).AddTicks(1558), "ADMIN01", "Plantilla de Tesis y Trabajo de investigación" },
                    { 7, new DateTime(2020, 6, 2, 22, 43, 16, 884, DateTimeKind.Local).AddTicks(1559), "ADMIN01", "Análisis bibliométrico" }
                });

            migrationBuilder.InsertData(
                table: "KnowledgeBase",
                columns: new[] { "QuestionId", "Answer", "CreationDate", "CreationUser", "InquiriesQuantity", "Pinned", "Question", "ServiceTypeId" },
                values: new object[,]
                {
                    { 1, "Respuesta para citación de figuras y tablas", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(761), "ADMIN01", 0, 0, "¿Cómo citar figuras o tablas?", 1 },
                    { 2, "Respuesta para el parafraseo", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1627), "ADMIN01", 0, 0, "¿Cómo es el parafraseo?", 1 },
                    { 3, "Respuesta para las notas a pie de página", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1645), "ADMIN01", 0, 0, "¿Qué son las notas a pie de página? ¿Cómo se usan?", 1 },
                    { 4, "Respuesta para reporte de coincidencias de Safe Assign", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1646), "ADMIN01", 0, 0, "Reporte de coincidencias de Safe Assign", 2 },
                    { 5, "Respuesta para búsqueda por temas", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1648), "ADMIN01", 0, 0, "Búsqueda por temas", 3 },
                    { 6, "Respuesta para búsqueda de revistas en cuartiles", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1649), "ADMIN01", 0, 0, "Búsqueda de revistas en cuartiles", 3 },
                    { 7, "Respuesta para revistas indexadas por disciplina", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1651), "ADMIN01", 0, 0, "Revistas indexadas por disciplina", 3 },
                    { 8, "Respuesta para instalar import to Mendeley", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1652), "ADMIN01", 0, 0, "¿Cómo instalar import to Mendeley?", 4 },
                    { 9, "Respuesta para instalar el plugin de word en Mendeley", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1654), "ADMIN01", 0, 0, "¿Cómo instalar el plugin de word en Mendeley?", 4 },
                    { 10, "Respuesta para búsqueda de artículos científicos", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1655), "ADMIN01", 0, 0, "¿Dónde puedo buscar artículos científicos?", 5 },
                    { 11, "Respuesta para ruta de plantillas de acuerdo a la carrera", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1656), "ADMIN01", 0, 0, "¿Dónde puedo encontrar plantillas de acuerdo a mi carrera?", 6 },
                    { 12, "Respuesta para análisis bibliométrico?", new DateTime(2020, 6, 2, 22, 43, 16, 886, DateTimeKind.Local).AddTicks(1658), "ADMIN01", 0, 0, "¿En qué se basa el análisis bibliométrico?", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeBase_ServiceTypeId",
                table: "KnowledgeBase",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttentionModes");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "KnowledgeBase");

            migrationBuilder.DropTable(
                name: "ServiceTypes");
        }
    }
}
