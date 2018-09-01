using FuDong.Common;

namespace FuDong.Data.DTO
{
    /// <summary>
    /// 关系DTO基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class DefaultRelationDTO<TKey> : IDefaultRelationDTO<TKey>
    {

    }
    /// <summary>
    /// 关系DTO基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class DefaultRelationDTO : DefaultRelationDTO<string> ,IDefaultRelationDTO<string>{ }

}