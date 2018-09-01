using FuDong.Common;
using GanGao.Data.Models;

namespace GanGao.Interfaces
{
    /// <summary>
    ///     仓储操作接口——部门信息
    /// </summary>
    public interface IDepartmentRepository : IRepository<string,DepartmentEntity>
    {
    }
}
