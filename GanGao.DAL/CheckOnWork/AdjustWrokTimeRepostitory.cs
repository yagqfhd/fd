using FuDong.DAL;
using GanGao.Data.Models.CheckOnWork;
using GanGao.Interfaces.CheckOnWork;
using System.ComponentModel.Composition;

namespace GanGao.DAL.CheckOnWork
{
    /// <summary>
    ///     仓储操作实现——调休工作
    /// </summary>
    [Export(typeof(IAdjustWrokTimeRepository<string, AdjustWorkTimeEntity>))]
    public class AdjustWrokTimeRepostitory:RepositoryBase<string, AdjustWorkTimeEntity>,
        IAdjustWrokTimeRepository<string, AdjustWorkTimeEntity>
    { }
    
}