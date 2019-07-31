using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Extensions
{
    public static class MappingExtension
    {
        public static TDest MapTo<TDest>(this object source)
        {
            return Mapper.Map<TDest>(source);
        }

        public static IList<TDest> MapList<TSource, TDest>(this IList<TSource> sources)
        {
            return sources
                .Select(s => Mapper.Map<TSource, TDest>(s))
                .ToList();
        }
    }
}
