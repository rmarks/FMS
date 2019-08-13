using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace FMS.DAL.Interfaces
{
    public interface IDataContext : IDisposable
    {
        DbSet<Company> Companies { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<CompanyAddress> CompanyAddresses { get; set; }
        DbSet<CompanyType> CompanyTypes { get; set; }
        DbSet<CompanyCompanyType> CompanyCompanyTypes { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<DeliveryTerm> DeliveryTerms { get; set; }
        DbSet<PaymentTerm> PaymentTerms { get; set; }
        DbSet<SalesOrder> SalesOrders { get; set; }
        DbSet<SalesOrderLine> SalesOrderLines { get; set; }
        DbSet<SalesInvoice> SalesInvoices { get; set; }
        DbSet<SalesInvoiceLine> SalesInvoiceLines { get; set; }
        DbSet<PriceList> PriceLists { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<ProductBase> ProductBases { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductSourceType> ProductSourceTypes { get; set; }
        DbSet<ProductDestinationType> ProductDestinationTypes { get; set; }
        DbSet<ProductStatus> ProductStatuses { get; set; }
        DbSet<ProductMaterial> ProductMaterials { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<ProductGroup> ProductGroups { get; set; }
        DbSet<ProductBrand> ProductBrands { get; set; }
        DbSet<ProductCollection> ProductCollections { get; set; }
        DbSet<ProductDesign> ProductDesigns { get; set; }
        DbSet<BusinessLine> BusinessLines { get; set; }

        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
