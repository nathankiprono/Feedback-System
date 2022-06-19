using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inquiry__Management__System.InquiryContext
{
    public class InquiryDbContext : DbContext
    {
        public InquiryDbContext(DbContextOptions<InquiryDbContext> options) : base(options)
        {

        }
        public DbSet<Inquiry__Management__System.Models.Agents> Agents { get; set; }
        public DbSet<Inquiry__Management__System.Models.Company_Information> Company_Information { get; set; }
        public DbSet<Inquiry__Management__System.Models.Customers> Customers { get; set; }
        public DbSet<Inquiry__Management__System.Models.Feedback> Feedbacks { get; set; }
        public DbSet<Inquiry__Management__System.Models.Products> Products { get; set; }
        public DbSet<Inquiry__Management__System.Models.AgentProductCost> AgentProductCosts { get; set; }
        public DbSet<Inquiry__Management__System.Models.Invoices> Invoices { get; set; }
        public DbSet<Inquiry__Management__System.Models.Payments> Payments { get; set; }
        public DbSet<Inquiry__Management__System.Models.Registration> Registrations { get; set; }
        public DbSet<Inquiry__Management__System.Models.Pager> Pagers { get; set; }
    }
}
