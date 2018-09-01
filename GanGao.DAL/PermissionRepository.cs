using FuDong.DAL;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System.ComponentModel.Composition;

namespace GanGao.DAL
{
    /// <summary>
    ///     仓储操作接口——权限信息
    /// </summary>
    [Export(typeof(IPermissionRepository))]
    public class PermissionRepository :
        RepositoryBase<string, PermissionEntity>,
        IPermissionRepository
    { }

    /// <summary>
    ///    仓储操作实现 -- 权限部门关系
    /// </summary>
    [Export(typeof(IPermissionDepartmentRepository))]
    public class PermissionDepartmentRepository :
        RelationRepositoryBase<string, PermissionDepartmentRelation>,
        IPermissionDepartmentRepository
    {

    }

    /// <summary>
    ///    仓储操作实现 -- 权限部门角色关系
    /// </summary>
    [Export(typeof(IPermissionDepartmentRoleRepository))]
    public class PermissionDepartmentRoleRepository :
        RelationRepositoryBase<string, PermissionDepartmentRoleRelation>,
        IPermissionDepartmentRoleRepository
    {

    }
}