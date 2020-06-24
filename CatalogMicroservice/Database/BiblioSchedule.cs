using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogMicroservice.Database
{
    public class BiblioSchedule
    {
        [Key]
        public string UPCCode { get; set; }
        public int CampusId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }

        // Foreign Key
        public BackofficeUser BackofficeUser { get; set; }
        public Campus Campus { get; set; }
    }
}
