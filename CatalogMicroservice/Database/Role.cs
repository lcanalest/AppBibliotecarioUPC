using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogMicroservice.Database
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }

        // Foreign Key
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
