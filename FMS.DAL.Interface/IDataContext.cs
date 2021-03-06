﻿using FMS.Domain.Model;
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
        DbSet<SalesOrderType> SalesOrderTypes { get; set; }
        DbSet<SalesOrder> SalesOrders { get; set; }
        DbSet<SalesOrderLine> SalesOrderLines { get; set; }
        DbSet<DeliveryType> DeliveryTypes { get; set; }
        DbSet<DeliveryHeader> DeliveryHeaders { get; set; }
        DbSet<DeliveryLine> DeliveryLines { get; set; }
        DbSet<SalesType> SalesTypes { get; set; }
        DbSet<SalesHeader> SalesHeaders { get; set; }
        DbSet<SalesLine> SalesLines { get; set; }
        DbSet<PriceList> PriceLists { get; set; }
        DbSet<Price> Prices { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<LocationType> LocationTypes { get; set; }
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
        DbSet<ProductVariation> ProductVariations { get; set; }
        DbSet<ProductBaseProductVariation> ProductBaseProductVariations { get; set; }
        DbSet<ProductSource> ProductSources { get; set; }
        DbSet<ProductDestination> ProductDestinations { get; set; }
        DbSet<Inventory> Inventory { get; set; }

        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
