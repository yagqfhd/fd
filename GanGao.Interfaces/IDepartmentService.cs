using FuDong.Common;
using GanGao.Data.DTO;
using GanGao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanGao.Interfaces
{
    /// <summary>
    /// 服务层 部门信息服务接口
    /// </summary>
    public interface IDepartmentService : IServices<string, DepartmentEntity, DepartmentDTO>
    {

    }
}
