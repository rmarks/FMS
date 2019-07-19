using AutoMapper;

namespace FMS.WPF.ViewModel.Utils
{
    public class MappingFactory
    {
        public static void MapTo<TSource, TDest>(TSource source, TDest dest)
        {
            Mapper.Map<TSource, TDest>(source, dest);
        }
    }
}
