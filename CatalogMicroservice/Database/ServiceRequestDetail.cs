using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Database
{
    public class ServiceRequestDetail
    {        
        public int ServiceRequestId { get; set; }
        public int ServiceRequestSequence { get; set; }
        public int ServiceStatusId { get; set; }
        public string AttentionDetail { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }

        // Foreign Key
        public ServiceRequest ServiceRequest { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
    }
}
