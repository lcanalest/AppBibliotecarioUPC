using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Models
{
    public class CreateServiceRequestDetailModel
    {
        public int ServiceRequestId { get; set; }
        public int ServiceStatusId { get; set; }
        public string AttentionDetail { get; set; }
        public string CreationUser { get; set; }
    }
}
