using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Models
{
    public class InfoServiceRequestByIdModel
    {
        public int ServiceRequestId { get; set; }
        public string UPCCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Names { get; set; }
        public string Email { get; set; }
        public string Career { get; set; }
        public string Modality { get; set; }
        public string ServiceType { get; set; }
        public string AttentionMode { get; set; }
        public string Campus { get; set; }
        public string RequestDetail { get; set; }
        public string FileName { get; set; }
        public string FileContent { get; set; } //Modificar para mostrar el contenido del archivo adjunto
        public int ServiceStatusId { get; set; }
        public string ServiceStatus { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
