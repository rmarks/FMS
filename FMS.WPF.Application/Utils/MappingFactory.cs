using AutoMapper;

namespace FMS.WPF.Application.Utils
{
    public class MappingFactory
    {
        public static TDest MapTo<TDest>(object source)
        {
            return Mapper.Map<TDest>(source);
        }

        public static void MapTo<TSource, TDest>(TSource source, TDest dest)
        {
            Mapper.Map<TSource, TDest>(source, dest);
        }
    }
}
