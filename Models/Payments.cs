using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inquiry__Management__System.Models
{
    public class Payments
    {
        [Key]
        public int Id { get; set; }

        public string Payment_Mode { get; set; }
        public double Amount { get; set; }
        public string Agent_Id { get; set; }

    }
}
