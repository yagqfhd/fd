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
    ///     仓储操作接口——调休工作
    /// </summary>
    public interface IAdjustWrokTimeRepository : IRepository<string, AdjustWorkTimeEntity>
    {
    }
}
