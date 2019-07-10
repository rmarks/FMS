﻿using FMS.DAL.EFCore;
using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interfaces;
using FMS.ServiceLayer.ProductServices.QueryObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.ServiceLayer.ProductServices
{
    public class ListProductsService : IListProductsService
    {
        private readonly IDataContext _context;

        public ListProductsService(IDataContext context)
        {
            _context = context;
        }

        public IList<ProductListDto> GetProducts(ProductListOptionsDto options)
        {
            return _context.ProductBases
                .AsNoTracking()
                .FilterBy(options)
                .OrderBy(p => p.ProductBaseCode)
                .ProjectBetween<ProductBase, ProductListDto>()
                .ToList();
        }
    }
}
