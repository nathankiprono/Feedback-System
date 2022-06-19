﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inquiry__Management__System.Models
{
    public class Products
    {
        [Key]
        public int Product_Id { get; set; }
        [Required]
        public string Product_Name { get; set; }
        [Required]
        public double Cost { get; set; }

    }
}
