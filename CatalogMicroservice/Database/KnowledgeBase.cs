using CatalogMicroservice.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Database
{
    public class KnowledgeBase
    {
        [Key]
        public int QuestionId { get; set; }
        public int ServiceTypeId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int InquiriesQuantity { get; set; }
        public int Pinned { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }

        // Foreign Key
        public ServiceType ServiceType { get; set; }
    }
}
