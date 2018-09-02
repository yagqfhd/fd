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
    [Export(typeof(IRoleService<string, RoleEntity>))]
    public class RoleService:
        DefaultServices<string, RoleEntity,IRoleRepository<string, RoleEntity>>,
        IRoleService<string, RoleEntity>
    {
    }
}