using AutoMapper.QueryableExtensions;
using FMS.DAL.Interfaces;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.ServiceLayer.Services
{
    public class ListProductSourceTypesService : IListProductSourceTypesService
    {
        private IDataContext _context;

        public ListProductSourceTypesService(IDataContext context)
        {
            _context = context;
        }

        public IList<ProductSourceTypeDto> GetProductSourceTypes()
        {
            return _context.ProductSourceTypes
                .AsNoTracking()
                .OrderBy(st => st.Name)
                .ProjectTo<ProductSourceTypeDto>()
                .ToList();
        }
    }
}
