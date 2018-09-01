using FuDong.Common;
using FuDong.DAL;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System.ComponentModel.Composition;

namespace GanGao.DAL
{
    /// <summary>
    ///     仓储操作实现——用户信息
    /// </summary>
    [Export(typeof(IUserRepository))]
    public class UserRepository :
        RepositoryBase<string, UserEntity>,
        IUserRepository
    { }

    /// <summary>
    ///    仓储操作实现 -- 用户部门关系
    /// </summary>
    [Export(typeof(IUserDepartmentRepository))]
    public class UserDepartmentRepository : 
        RelationRepositoryBase<string, UserDepartmentRelation>,
        IUserDepartmentRepository
    {

    }

    /// <summary>
    ///    仓储操作实现 -- 用户部门角色关系
    /// </summary>
    [Export(typeof(IUserDepartmentRoleRepository))]
    public class UserDepartmentRoleRepository : 
        RelationRepositoryBase<string, UserDepartmentRoleRelation>,
        IUserDepartmentRoleRepository
    {

    }
}