using AutoMapper.QueryableExtensions;
using System.Linq;

namespace FMS.ServiceLayer.Extensions
{
    public static class MappingExtension
    {
        public static IQueryable<TDest> ProjectBetween<TSource, TDest>(this IQueryable<TSource> sources)
        {
            return sources
                .ProjectTo<TDest>();
        }
    }
}
