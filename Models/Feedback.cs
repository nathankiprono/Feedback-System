using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inquiry__Management__System.Models
{
    public class Feedback
    {
        [Key]
        public int Feedback_Id { get; set; }
        public string Customer_Id { get; set; }
        public string Product_Id { get; set; }
        [Required]
        public string Results { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public double Cost { get; set; }
       
        public string IsInvoice { get; set; }
        public string Invoice_Date { get; set; }
        public string Ispaid { get; set; }
        public int Invoice_No { get; set; }
        public string Payment_Date { get; set; }
        public string Payment_Ref { get; set; }
    }
}
