using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models
{
    /// <summary>
    /// 部门实体定义
    /// </summary>
    public class DepartmentEntity : DefaultEntity<string>, IDefaultEntity<string>
    {
        /// <summary>
        /// 上级部门
        /// </summary>
        public virtual DepartmentEntity Parent { get; set; }
        /// <summary>
        /// 下级部门集合
        /// </summary>
        public virtual ICollection<DepartmentEntity> Childs { get; set; }

        #region ///////// 构造器

        public DepartmentEntity():base()
        {
            Id = Guid.NewGuid().ToString();
            Childs = new HashSet<DepartmentEntity>();
        }

        #endregion
    }

    
}