﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Database
{
    public class ServiceType
    {
        [Key]
        public int ServiceTypeId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }

        // Foreign Key
        public virtual ICollection<KnowledgeBase> KnowledgeBase { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequest { get; set; }
        
    }
}
