using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Services
{
    public class ProductDropdownsService : IProductDropdownsService
    {
        private IDataContextFactory _contextFactory;

        public ProductDropdownsService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ProductDropdownsDto> GetProductDropdownsAsync()
        {
            using (var context = _contextFactory.CreateContext())
            {
                var dto = new ProductDropdownsDto();

                dto.ProductSourceTypes = await GetProductSourceTypesAsync(context);
                dto.ProductDestinationTypes = await GetProductDestinationTypesAsync(context);

                return dto;
            }
        }

        #region Helpers
        private async Task<IList<ProductSourceTypeDropdownDto>> GetProductSourceTypesAsync(IDataContext context)
        {
            return await context.ProductSourceTypes
                .AsNoTracking()
                .OrderBy(st => st.Name)
                .ProjectBetween<ProductSourceType, ProductSourceTypeDropdownDto>()
                .ToListAsync();
        }

        private async Task<IList<ProductDestinationTypeDropdownDto>> GetProductDestinationTypesAsync(IDataContext context)
        {
            return await context.ProductDestinationTypes
                .AsNoTracking()
                .OrderBy(pd => pd.Name)
                .ProjectBetween<ProductDestinationType, ProductDestinationTypeDropdownDto>()
                .ToListAsync();
        }
        #endregion Helpers
    }
}
