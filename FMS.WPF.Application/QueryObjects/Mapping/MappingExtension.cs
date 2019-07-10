using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class MappingExtension
    {
        public static IList<TDest> MapBetween<TSource, TDest>(this IList<TSource> sources)
        {
            return sources
                .Select(s => Mapper.Map<TSource, TDest>(s))
                .ToList();
        }

        public static TDest MapTo<TDest>(this object source)
        {
            return Mapper.Map<TDest>(source);
        }
    }
}
