using FuDong.BLL;
using GanGao.Data.DTO;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System.ComponentModel.Composition;

namespace GanGao.BLL
{
    /// <summary>
    /// 部门服务层
    /// </summary>
    [Export(typeof(IDepartmentService<string, DepartmentEntity>))]
    public class DepartmentService : DefaultServices<string, DepartmentEntity, IDepartmentRepository<string, DepartmentEntity>>, IDepartmentService<string, DepartmentEntity>
    {

    }
}