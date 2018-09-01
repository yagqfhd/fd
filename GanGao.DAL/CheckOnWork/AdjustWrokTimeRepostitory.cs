using FuDong.DAL;
using GanGao.Data.Models.CheckOnWork;
using GanGao.Interfaces;
using GanGao.Interfaces.CheckOnWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.DAL.CheckOnWork
{
    /// <summary>
    ///     仓储操作实现——调休工作
    /// </summary>
    public class AdjustWrokTimeRepostitory:RepositoryBase<string, AdjustWorkTimeEntity>,
        IAdjustWrokTimeRepository
    { }
    
}