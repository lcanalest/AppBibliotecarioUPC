using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Models
{
    public class StudentModel
    {
        public string name { get; set; }
        public string apellido { get; set; }

        //public IFormFile Image { get; set; }
    }
}
