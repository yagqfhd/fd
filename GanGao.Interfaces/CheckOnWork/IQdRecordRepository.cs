using FuDong.Common;
using GanGao.Data.Models.CheckOnWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanGao.Interfaces.CheckOnWork
{
    /// <summary>
    ///     仓储操作接口——签到记录
    /// </summary>
    public interface IQdRecordRepository : IRepository<string, QdRecordEntity>
    {
    }
}
