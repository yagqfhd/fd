using FuDong.Common;
using FuDong.Validators;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System.ComponentModel.Composition;

namespace GanGao.BLL.Validators
{
    /// <summary>
    ///     校验实现——权限信息名称重名检查
    /// </summary>
    [Export(typeof(IEntityValidator<PermissionEntity>))]
    public class PermissionValidator:ValidatorBase<string, PermissionEntity, IPermissionRepository<string, PermissionEntity>>, IEntityValidator<PermissionEntity>
    {
    }
}