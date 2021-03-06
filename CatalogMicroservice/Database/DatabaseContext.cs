﻿using CatalogMicroservice.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<AttentionMode> AttentionModes { get; set; }
        public DbSet<Campus> Campus { get; set; }        
        public DbSet<KnowledgeBase> KnowledgeBase { get; set; }
        public DbSet<ServiceStatus> ServiceStatus { get; set; }
        public DbSet<BackofficeUser> BackofficeUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<BiblioSchedule> BiblioSchedule { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<ServiceRequestDetail> ServiceRequestDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ServiceType>()
                .HasKey(s => new { s.ServiceTypeId });

            modelBuilder.Entity<AttentionMode>()
                .HasKey(a => new { a.AttentionModeId });

            modelBuilder.Entity<Campus>()
                .HasKey(c => new { c.CampusId });

            modelBuilder.Entity<KnowledgeBase>()
                .HasKey(k => new { k.QuestionId });

            modelBuilder.Entity<KnowledgeBase>()
                .HasOne(s => s.ServiceType)
                .WithMany(k => k.KnowledgeBase)
                .HasForeignKey(s => s.ServiceTypeId);

            modelBuilder.Entity<ServiceStatus>()
                .HasKey(ss => new { ss.ServiceStatusId });

            modelBuilder.Entity<BackofficeUser>()
                .HasKey(bu => new { bu.BUserCode });

            modelBuilder.Entity<Role>()
                .HasKey(r => new { r.RoleId});

            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.BUserCode, ur.RoleId });

            modelBuilder.Entity<UserRoles>()
                .HasOne(r => r.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(r => r.RoleId);            

            modelBuilder.Entity<BiblioSchedule>()
                .HasKey(bs => new { bs.BUserCode, bs.CampusId, bs.StartTime, bs.EndTime });

            modelBuilder.Entity<BiblioSchedule>()
                .HasOne(bu => bu.BackofficeUser)
                .WithMany(bs => bs.BiblioSchedule)
                .HasForeignKey(bu => bu.BUserCode);

            modelBuilder.Entity<BiblioSchedule>()
                .HasOne(c => c.Campus)
                .WithMany(bs => bs.BiblioSchedule)
                .HasForeignKey(c => c.CampusId);

            modelBuilder.Entity<ServiceRequest>()
                .HasKey(sr => new { sr.ServiceRequestId });

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(st => st.ServiceType)
                .WithMany(sr => sr.ServiceRequest)
                .HasForeignKey(st => st.ServiceTypeId);

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(am => am.AttentionMode)
                .WithMany(sr => sr.ServiceRequest)
                .HasForeignKey(am => am.AttentionModeId);

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(c => c.Campus)
                .WithMany(sr => sr.ServiceRequest)
                .HasForeignKey(c => c.CampusId);

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(ss => ss.ServiceStatus)
                .WithMany(sr => sr.ServiceRequest)
                .HasForeignKey(ss => ss.ServiceStatusId);

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(bu => bu.BackofficeUser)
                .WithMany(sr => sr.ServiceRequest)
                .HasForeignKey(bu => bu.BUserCode);

            modelBuilder.Entity<ServiceRequestDetail>()
                .HasKey(srd => new { srd.ServiceRequestId, srd.ServiceRequestSequence });

            modelBuilder.Entity<ServiceRequestDetail>()
                .HasOne(sr => sr.ServiceRequest)
                .WithMany(srd => srd.ServiceRequestDetail)
                .HasForeignKey(sr => sr.ServiceRequestId);

            modelBuilder.Entity<ServiceRequestDetail>()
                .HasOne(ss => ss.ServiceStatus)
                .WithMany(srd => srd.ServiceRequestDetail)
                .HasForeignKey(ss => ss.ServiceStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<ServiceType>()
                .HasData(
                new ServiceType
                {
                    ServiceTypeId = 1,
                    Description = "Normas de citación y referencias",                    
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new ServiceType
                {
                    ServiceTypeId = 2,
                    Description = "Test de Similitud",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new ServiceType
                {
                    ServiceTypeId = 3,
                    Description = "Búsqueda de información",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new ServiceType
                {
                    ServiceTypeId = 4,
                    Description = "Gestores de referencias (Mendeley)",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new ServiceType
                {
                    ServiceTypeId = 5,
                    Description = "Búsqueda de artículos científicos",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new ServiceType
                {
                    ServiceTypeId = 6,
                    Description = "Plantilla de Tesis y Trabajo de investigación",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new ServiceType
                {
                    ServiceTypeId = 7,
                    Description = "Análisis bibliométrico",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new ServiceType
                {
                    ServiceTypeId = 8,
                    Description = "Asesoría",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                }
                );

            modelBuilder
                .Entity<AttentionMode>()
                .HasData(
                new AttentionMode
                {
                    AttentionModeId = 1,
                    Description = "Presencial",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new AttentionMode
                {
                    AttentionModeId = 2,
                    Description = "Virtual",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                }
                );

            modelBuilder
                .Entity<Campus>()
                .HasData(
                new Campus
                {
                    CampusId = 1,
                    Description = "Campus Monterrico",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new Campus
                {
                    CampusId = 2,
                    Description = "Campus Villa",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new Campus
                {
                    CampusId = 3,
                    Description = "Campus San Miguel",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new Campus
                {
                    CampusId = 4,
                    Description = "Campus San Isidro",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new Campus
                {
                    CampusId = 5,
                    Description = "No Aplica",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                }
                );

            modelBuilder
                .Entity<KnowledgeBase>()
                .HasData(
                new KnowledgeBase
                {
                    QuestionId = 1,
                    ServiceTypeId = 1,
                    Question = "¿Cómo citar figuras o tablas?",
                    Answer = "Respuesta para citación de figuras y tablas",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 2,
                    ServiceTypeId = 1,
                    Question = "¿Cómo es el parafraseo?",
                    Answer = "Respuesta para el parafraseo",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 3,
                    ServiceTypeId = 1,
                    Question = "¿Qué son las notas a pie de página? ¿Cómo se usan?",
                    Answer = "Respuesta para las notas a pie de página",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 4,
                    ServiceTypeId = 2,
                    Question = "Reporte de coincidencias de Safe Assign",
                    Answer = "Respuesta para reporte de coincidencias de Safe Assign",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 5,
                    ServiceTypeId = 3,
                    Question = "Búsqueda por temas",
                    Answer = "Respuesta para búsqueda por temas",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 6,
                    ServiceTypeId = 3,
                    Question = "Búsqueda de revistas en cuartiles",
                    Answer = "Respuesta para búsqueda de revistas en cuartiles",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 7,
                    ServiceTypeId = 3,
                    Question = "Revistas indexadas por disciplina",
                    Answer = "Respuesta para revistas indexadas por disciplina",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 8,
                    ServiceTypeId = 4,
                    Question = "¿Cómo instalar import to Mendeley?",
                    Answer = "Respuesta para instalar import to Mendeley",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 9,
                    ServiceTypeId = 4,
                    Question = "¿Cómo instalar el plugin de word en Mendeley?",
                    Answer = "Respuesta para instalar el plugin de word en Mendeley",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 10,
                    ServiceTypeId = 5,
                    Question = "¿Dónde puedo buscar artículos científicos?",
                    Answer = "Respuesta para búsqueda de artículos científicos",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 11,
                    ServiceTypeId = 6,
                    Question = "¿Dónde puedo encontrar plantillas de acuerdo a mi carrera?",
                    Answer = "Respuesta para ruta de plantillas de acuerdo a la carrera",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new KnowledgeBase
                {
                    QuestionId = 12,
                    ServiceTypeId = 7,
                    Question = "¿En qué se basa el análisis bibliométrico?",
                    Answer = "Respuesta para análisis bibliométrico?",
                    InquiriesQuantity = 0,
                    Pinned = 0,
                    PositiveCalification = 0,
                    NegativeCalification = 0,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                }
                );

            modelBuilder
                .Entity<ServiceStatus>()
                .HasData(
                new ServiceStatus
                {
                    ServiceStatusId = 1,
                    Description = "Registrada",                    
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new ServiceStatus
                {
                    ServiceStatusId = 2,
                    Description = "Asignada",                    
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new ServiceStatus
                {
                    ServiceStatusId = 3,
                    Description = "En atención",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new ServiceStatus
                {
                    ServiceStatusId = 4,
                    Description = "Cerrada",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                }
                );

            modelBuilder
                .Entity<BackofficeUser>()
                .HasData(
                new BackofficeUser
                {
                    BUserCode = "b20200601",
                    FirstName = "Mármol",
                    LastName = "Coloma",
                    Names = "Roberto André",
                    Email = "b20200601@upc.edu.pe",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new BackofficeUser
                {
                    BUserCode = "s20200601",                    
                    FirstName = "Chumacero",
                    LastName = "Cruz",
                    Names = "Luigui",
                    Email = "s20200601@upc.edu.pe",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                }
                );

            modelBuilder
                .Entity<Role>()
                .HasData(
                new Role
                {
                    RoleId = 1,
                    Description = "Bibliotecólogo",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new Role
                {
                    RoleId = 2,
                    Description = "Supervisor",
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                }
                );

            modelBuilder
                .Entity<UserRoles>()
                .HasData(
                new UserRoles
                {
                    BUserCode = "b20200601",
                    RoleId = 1,                    
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                },
                new UserRoles
                {
                    BUserCode = "s20200601",
                    RoleId = 2,
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                }
                );

            modelBuilder
                .Entity<BiblioSchedule>()
                .HasData(
                new BiblioSchedule
                {
                    BUserCode = "b20200601",
                    CampusId = 1,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddHours(4),
                    CreationDate = DateTime.Now,
                    CreationUser = "ADMIN01"
                });
        }
    }
}
