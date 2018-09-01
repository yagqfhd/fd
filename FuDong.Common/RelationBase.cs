using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FuDong.Common
{
    /// <summary>
    ///     可持久到数据库的领域关联模型的基类。
    /// </summary>
    [Serializable]
    public abstract class RelationBase<TKey>
    {
        #region 属性
        /// <summary>
        ///     获取或设置 版本控制标识，用于处理并发
        /// </summary>
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Timestamp { get; set; }
        #endregion
    }
}