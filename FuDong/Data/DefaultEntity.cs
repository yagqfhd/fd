using FuDong.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace FuDong.Data
{
    /// <summary>
    ///     默认领域模型的基类。
    /// </summary>
    public class DefaultEntity<TKey> : EntityBase<TKey>, IDefaultEntity<TKey>
    {
        #region 构造函数

        /// <summary>
        ///     数据实体基类
        /// </summary>
        protected DefaultEntity():base()
        {
            
        }

        #endregion

        #region 属性
        /// <summary>
        /// ID 主键
        /// </summary>
        public TKey Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        #endregion
    }

    /// <summary>
    ///     默认领域模型的基类。
    /// </summary>
    public abstract class DefaultEntity : DefaultEntity<string> , IDefaultEntity<string>
    {
        /// <summary>
        ///     数据实体基类
        /// </summary>
        protected DefaultEntity():base()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}