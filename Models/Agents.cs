using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inquiry__Management__System.Models
{
    public class Agents
    {
        [Key]
        public int Agent_Id { get; set; }
        [Required]
        public string Agent_Name{ get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone_Number{ get; set; }
       // [Required]
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
