using AutoMapper;
using FuDong.Common;

namespace FuDong.Data
{
    /// <summary>
    /// 数据 DTO 转化服务
    /// </summary>
    //[Export(typeof(IDTOMapService))]
    public class DefaultDTOMapService : IDTOMapService
    {
        public virtual TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public virtual TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
        public virtual TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source, destination);
        }

    }
}