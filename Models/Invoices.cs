using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inquiry__Management__System.Models
{
    public class Invoices
    {
        [Key]
        public int Id { get; set; }
        public string Agent_Id { get; set; }
        public string Customer_Id { get; set; }

        public string Invoice_No { get; set; }
        public string Date { get; set; }
        public string Product_Id { get; set; }

    }
}
