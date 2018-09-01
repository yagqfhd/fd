using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models
{
    /// <summary>
    /// 权限实体
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class PermissionEntity: DefaultEntity<string>, IDefaultEntity<string>
    {
        #region    属性定义
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Parameters { get; set; }
        #endregion
        /// <summary>
        /// 权限部门集合
        /// </summary>
        public virtual ICollection<PermissionDepartmentRelation> Departments { get; protected set; }

        public PermissionEntity():base()
        {
            this.Departments = new HashSet<PermissionDepartmentRelation>();
            this.Id = Guid.NewGuid().ToString();
        }
    }
    
}