using AutoMapper;

namespace FMS.WPF.Application.Extensions
{
    public static class MappingExtension
    {
        public static TDest MapTo<TDest>(this object source)
        {
            return Mapper.Map<TDest>(source);
        }
    }
}
