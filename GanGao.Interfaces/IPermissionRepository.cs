using FuDong.Common;
using GanGao.Data.Models;

namespace GanGao.Interfaces
{
    /// <summary>
    ///     仓储操作接口——权限信息
    /// </summary>
    public interface IPermissionRepository : IRepository<string,PermissionEntity>
    {
    }

    /// <summary>
    ///    仓储操作接口——权限部门角色仓储接口
    /// </summary>
    public interface IPermissionDepartmentRepository : IRelationRepository<string, PermissionDepartmentRelation>
    {
    }
    /// <summary>
    ///    仓储操作接口——权限部门角色仓储接口
    /// </summary>
    public interface IPermissionDepartmentRoleRepository : IRelationRepository<string, PermissionDepartmentRoleRelation>
    {
    }
}
