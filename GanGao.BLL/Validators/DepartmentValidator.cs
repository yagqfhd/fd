using FuDong.Common;
using FuDong.Validators;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System.ComponentModel.Composition;
namespace GanGao.BLL.Validators
{
    /// <summary>
    ///     校验实现——部门信息名称重名检查
    /// </summary>
    [Export(typeof(IEntityValidator<DepartmentEntity>))]
    public class DepartmentValidator : ValidatorBase<string, DepartmentEntity, IDepartmentRepository<string,DepartmentEntity>>, IEntityValidator<DepartmentEntity>
    {
        
    }
}