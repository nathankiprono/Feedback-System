using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inquiry__Management__System.Models
{
    public class Customers
    {
        [Key]
        [MaxLength(50)]
        public string Customer_Id { get; set; }
        public string Agent_Id { get; set; }
      //  [Required]
        public string FullName { get; set; }
      //  [Required]
        public string Gender { get; set; }
       // [Required]
        public string Passport_No { get; set; }
        public string Height { get; set; }
       // [Required]
        public string National_Id { get; set; }
       // [Required]
        public string Nationality { get; set; }
       // [Required]
        public string DOB { get; set; }
      
        public string Notes { get; set; }
      
        public string Weight { get; set; }
       // [Required]
        public string RegistrationDate { get; set; }
       // [Required]
        public string Location { get; set; }




    }
}
