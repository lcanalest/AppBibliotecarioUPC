using System;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationMicroservice.Database
{
    public class UserLogins
    {
        [Key]
        public int LoginId { get; set; }
        public string UPCCode { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Names { get; set; }        
        public string Career { get; set; }
        public string Modality { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
    }
}
