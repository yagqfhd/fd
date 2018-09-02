using FuDong.DAL;
using GanGao.Data.Models.CheckOnWork;
using GanGao.Interfaces.CheckOnWork;
using System.ComponentModel.Composition;

namespace GanGao.DAL.CheckOnWork
{
    /// <summary>
    ///     仓储操作实现——工作时间
    /// </summary>
    [Export(typeof(IWrokTimeRepository<string, WorkTimeEntity>))]
    public class WorkTimeRepostitory : RepositoryBase<string, WorkTimeEntity>,
        IWrokTimeRepository<string, WorkTimeEntity>
    { }
}