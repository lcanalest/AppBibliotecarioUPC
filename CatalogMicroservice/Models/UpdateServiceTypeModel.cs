﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogMicroservice.Models
{
    public class UpdateServiceTypeModel
    {
        public int ServiceTypeId { get; set; }
        public string Description { get; set; }
        public string CreationUser { get; set; }
    }
}
