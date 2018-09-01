using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models
{
    /// <summary>
    /// 用户部门关连实体
    /// </summary>
    public class UserDepartmentRelation : DefaultRelation<string>, IDefaultRelation<string>
    {
        public string UserId { get; set; }
        public string DepartmentId { get; set; }
        /// <summary>
        /// 部门实体
        /// </summary>
        //[ForeignKey("DepartmentId")]
        public virtual DepartmentEntity Department { get; set; } //virtual 

        /// <summary>
        /// 部门下的角色集合
        /// </summary>
        public virtual ICollection<UserDepartmentRoleRelation> Roles { get; }

        public UserDepartmentRelation() { Roles = new HashSet<UserDepartmentRoleRelation>(); }
    }

    
}