using FuDong.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace FuDong.Data
{
    /// <summary>
    ///     默认领域模型关系的基类。
    /// </summary>
    public class DefaultRelation<TKey> : RelationBase<TKey>, IDefaultRelation<TKey>
    {
    }
    /// <summary>
    ///     默认领域模型关系的基类。
    /// </summary>
    public  class DefaultRelation : DefaultRelation<string>,IDefaultRelation<string>
    { }
}