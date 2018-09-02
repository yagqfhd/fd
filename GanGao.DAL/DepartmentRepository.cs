using FuDong.DAL;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System.ComponentModel.Composition;

namespace GanGao.DAL
{
    /// <summary>
    ///     仓储操作实现——部门信息
    /// </summary>
    [Export(typeof(IDepartmentRepository<string, DepartmentEntity>))]
    public class DepartmentRepository :
        RepositoryBase<string, DepartmentEntity>,
        IDepartmentRepository<string, DepartmentEntity>
    { }
}