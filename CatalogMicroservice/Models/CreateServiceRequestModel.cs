using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Models
{
    public class CreateServiceRequestModel
    {
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
        public IFormFile FileContent { get; set; }
        public string CreationUser { get; set; }
    }
}
