using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.DAL.EFCore
{
    public class SQLServerDbContext : DbContext, IDataContext
    {
        #region properties
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CompanyAddress> CompanyAddresses { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<CompanyCompanyType> CompanyCompanyTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DeliveryTerm> DeliveryTerms { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderLine> SalesOrderLines { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesInvoiceLine> SalesInvoiceLines { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<Price> Prices { get; set; }
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
        public DbSet<ProductVariation> ProductVariations { get; set; }
        public DbSet<ProductBaseProductVariation> ProductBaseProductVariations { get; set; }
        public DbSet<ProductSource> ProductSources { get; set; }
        public DbSet<ProductDestination> ProductDestinations { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DELL-PC\SQLEXPRESS2014;Database=FMS;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<CompanyCompanyType>()
            //    .HasKey(c => new { c.CompanyId, c.CompanyTypeId });

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            modelBuilder.Entity<SalesInvoice>(entity =>
            {
                entity.HasOne(si => si.Company)
                    .WithMany()
                    .HasForeignKey(si => si.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.BillingAddress)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.ShippingAddress)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SalesOrder>()
                .HasOne(so => so.Company)
                .WithMany()
                .HasForeignKey(so => so.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(s => s.BillingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(s => s.ShippingAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
