using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuDong.Common
{
    /// <summary>
    /// DTO 实体基类接口
    /// </summary>
    public interface IDefaultEntityDTO<TKey>
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
