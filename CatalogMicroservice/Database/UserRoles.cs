using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogMicroservice.Database
{
    public class UserRoles
    {
        [Key]
        public string BUserCode { get; set; }        
        public int RoleId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }

        // Foreign Key
        public Role Role { get; set; }
    }
}
