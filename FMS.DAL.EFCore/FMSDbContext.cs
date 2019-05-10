﻿using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace FMS.DAL.EFCore
{
    public class FMSDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DELL-PC\SQLEXPRESS2014;Database=FMS;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
    }
}