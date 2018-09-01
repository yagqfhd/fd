using FuDong.DAL;
using GanGao.Data.Models.CheckOnWork;
using GanGao.Interfaces.CheckOnWork;

namespace GanGao.DAL.CheckOnWork
{
    /// <summary>
    ///     仓储操作实现——签到记录
    /// </summary>
    public class QdRecordRepostitory : RepositoryBase<string, QdRecordEntity>,
        IQdRecordRepository
    { }
}