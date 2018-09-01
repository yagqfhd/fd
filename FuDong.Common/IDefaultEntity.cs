using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuDong.Common
{
    /// <summary>
    /// 通用实体类接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IDefaultEntity<TKey>
    {
        /// <summary>
        /// ID
        /// </summary>
        TKey Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        string Description { get; set; }        
    }
        
}
