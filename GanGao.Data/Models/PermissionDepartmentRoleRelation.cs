using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models
{
    /// <summary>
    /// 权限部门角色关连实体
    /// </summary>
    public class PermissionDepartmentRoleRelation : DefaultRelation<string>, IDefaultRelation<string>
    {
        public string PermissionId { get; set; }
        public string DepartmentId { get; set; }
        public string RoleId { get; set; }

        /// <summary>
        /// 对应的角色
        /// </summary>
        public virtual RoleEntity Role { get; set; }
    }

    
}