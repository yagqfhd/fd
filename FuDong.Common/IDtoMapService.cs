using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuDong.Common
{
    /// <summary>
    /// DTO模型映射到Model的服务接口定义
    /// </summary>
    public interface IDTOMapService
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
