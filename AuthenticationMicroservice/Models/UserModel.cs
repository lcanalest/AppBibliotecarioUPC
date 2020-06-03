using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationMicroservice.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UPCCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Names { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Career { get; set; }
        public string Token { get; set; }
    }
}
