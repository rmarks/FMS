using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.ServiceLayer.Services
{
    public class ListProductDestinationTypesService : IListProductDestinationTypesService
    {
        private IDataContext _context;

        public ListProductDestinationTypesService(IDataContext context)
        {
            _context = context;
        }

        public IList<ProductDestinationTypeDto> GetProductDestinationTypes()
        {
            return _context.ProductDestinationTypes
                .AsNoTracking()
                .OrderBy(pd => pd.Name)
                .ProjectBetween<ProductDestinationType, ProductDestinationTypeDto>()
                .ToList();
        }
    }
}
