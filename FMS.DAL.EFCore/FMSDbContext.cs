using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.DAL.EFCore
{
    public class FMSDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DeliveryTerm> DeliveryTerms { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DELL-PC\SQLEXPRESS2014;Database=FMS;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
    }
}
