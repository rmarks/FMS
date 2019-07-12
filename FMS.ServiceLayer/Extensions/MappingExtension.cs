using AutoMapper;
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

        public static TDest MapTo<TDest>(this object source)
        {
            return Mapper.Map<TDest>(source);
        }
    }
}
