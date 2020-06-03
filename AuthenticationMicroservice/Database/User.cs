using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Entities
{
    public class User
    {
        public User()
        {            
            CreationDate = DateTime.Now; // Valor por defecto para inicializar el objeto
        }

        [Key]
        public int UserId { get; set; }
        public string UPCCode { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Names { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Career { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
    }
}
