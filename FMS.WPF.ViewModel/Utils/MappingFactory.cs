using AutoMapper;

namespace FMS.WPF.ViewModel.Utils
{
    public class MappingFactory
    {
        public static void MapTo<TSource, TDest>(TSource source, TDest dest)
        {
            Mapper.Map<TSource, TDest>(source, dest);
        }

        public static TDest MapTo<TDest>(object source)
        {
            return Mapper.Map<TDest>(source);
        }
    }
}
