using FuDong.Common;
using FuDong.Validators;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System.ComponentModel.Composition;

namespace GanGao.BLL.Validators
{
    /// <summary>
    ///     校验实现——用户信息名称重名检查
    /// </summary>
    [Export(typeof(IEntityValidator<RoleEntity>))]
    public class RoleValidator:ValidatorBase<string, RoleEntity, IRoleRepository<string, RoleEntity>>, IEntityValidator<RoleEntity>
    {

    }
}