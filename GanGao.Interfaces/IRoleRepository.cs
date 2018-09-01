using FuDong.Common;
using GanGao.Data.Models;

namespace GanGao.Interfaces
{
    /// <summary>
    ///     仓储操作接口——角色信息
    /// </summary>
    public interface IRoleRepository : IRepository<string,RoleEntity>
    {
    }
}
