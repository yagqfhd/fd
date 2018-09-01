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
    ///     仓储操作接口——工作时间
    /// </summary>
    public interface IWrokTimeRepository : IRepository<string, WorkTimeEntity>
    {
    }
}
