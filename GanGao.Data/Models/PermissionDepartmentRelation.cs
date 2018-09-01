using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models
{
    /// <summary>
    /// 权限部门关连实体
    /// </summary>
    public class PermissionDepartmentRelation : DefaultRelation<string>, IDefaultRelation<string>
    {
        public string PermissionId { get; set; }
        public string DepartmentId { get; set; }
        /// <summary>
        /// 部门实体
        /// </summary>
        //[ForeignKey("DepartmentId")]
        public virtual DepartmentEntity Department { get; set; } //virtual 

        /// <summary>
        /// 部门下的角色集合
        /// </summary>
        public virtual ICollection<PermissionDepartmentRoleRelation> Roles { get; }

        public PermissionDepartmentRelation() { Roles = new HashSet<PermissionDepartmentRoleRelation>(); }
    }

    
}