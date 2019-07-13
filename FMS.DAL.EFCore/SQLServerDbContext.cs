using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.DAL.EFCore
{
    public class SQLServerDbContext : DbContext, IDataContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DeliveryTerm> DeliveryTerms { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderLine> SalesOrderLines { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesInvoiceLine> SalesInvoiceLines { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ProductBase> ProductBases { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSourceType> ProductSourceTypes { get; set; }
        public DbSet<ProductDestinationType> ProductDestinationTypes { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductCollection> ProductCollections { get; set; }
        public DbSet<ProductDesign> ProductDesigns { get; set; }
        public DbSet<BusinessLine> BusinessLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DELL-PC\SQLEXPRESS2014;Database=FMS;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
