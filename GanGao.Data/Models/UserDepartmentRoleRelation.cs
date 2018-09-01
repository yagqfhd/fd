using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models
{
    /// <summary>
    /// 用户部门角色关连实体
    /// </summary>
    public class UserDepartmentRoleRelation: DefaultRelation<string>, IDefaultRelation<string>
    {
        public string UserId { get; set; }
        public string DepartmentId { get; set; }
        public string RoleId { get; set; }

        /// <summary>
        /// 对应的角色
        /// </summary>
        public virtual RoleEntity Role { get; set; }
    }
    }