using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models
{
   
    /// <summary>
    /// 角色实体
    /// </summary>
    public class RoleEntity : DefaultEntity<string>, IDefaultEntity<string>
    {
        public RoleEntity() :base()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}