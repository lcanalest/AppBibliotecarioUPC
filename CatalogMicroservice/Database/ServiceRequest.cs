using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogMicroservice.Database
{
    public class ServiceRequest
    {
        [Key]
        public int ServiceRequestId { get; set; }
        public string UPCCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Names { get; set; }
        public string Email { get; set; }
        public string Career { get; set; }
        public string Modality { get; set; }
        public int ServiceTypeId { get; set; }
        public int AttentionModeId { get; set; }
        public int CampusId { get; set; }
        public string RequestDetail { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public int ServiceStatusId { get; set; }
        public string BUserCode { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }

        // Foreign Key
        public ServiceType ServiceType { get; set; }
        public AttentionMode AttentionMode { get; set; }
        public Campus Campus { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
        public BackofficeUser BackofficeUser { get; set; }
        public virtual ICollection<ServiceRequestDetail> ServiceRequestDetail { get; set; }
    }
}
