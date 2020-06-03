using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Models
{
    public class KnowledgeBaseModel
    {
        public string ServiceTypeDescription { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }          
        public int InquiriesQuantity { get; set; }          
    }
}
