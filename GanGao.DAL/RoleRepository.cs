using FuDong.DAL;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System.ComponentModel.Composition;

namespace GanGao.DAL
{
    /// <summary>
    ///     仓储操作实现——角色信息
    /// </summary>
    [Export(typeof(IRoleRepository))]
    public class RoleRepository :
        RepositoryBase<string, RoleEntity>,
        IRoleRepository
    { }
}