using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inquiry__Management__System.Models
{
    public class Company_Information
    {
        [Key]
        public int Company_Id { get; set; }
        [Required]
        public string Company_Name { get; set; }
        [Required]
        public string Conctacts { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
