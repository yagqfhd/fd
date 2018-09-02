using FuDong.DAL;
using GanGao.Data.Models.CheckOnWork;
using GanGao.Interfaces.CheckOnWork;
using System.ComponentModel.Composition;

namespace GanGao.DAL.CheckOnWork
{
    /// <summary>
    ///     仓储操作实现——签到记录
    /// </summary>
    [Export(typeof(IQdRecordRepository<string, QdRecordEntity>))]
    public class QdRecordRepostitory: RepositoryBase<string, QdRecordEntity>,
        IQdRecordRepository<string, QdRecordEntity>
    { }
}