using FuDong.Common;
using GanGao.Data.Models;

namespace GanGao.Interfaces
{
    /// <summary>
    ///     仓储操作接口——用户仓储操作接口
    /// </summary>
    public interface IUserRepository : IRepository<string,UserEntity>
    {
    }

    /// <summary>
    ///    仓储操作接口——用户部门角色仓储接口
    /// </summary>
    public interface IUserDepartmentRepository : IRelationRepository<string, UserDepartmentRelation>
    {
    }
    /// <summary>
    ///     仓储操作接口——用户部门角色仓储接口
    /// </summary>
    public interface IUserDepartmentRoleRepository : IRelationRepository<string, UserDepartmentRoleRelation>
    {
    }
}
