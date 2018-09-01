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
    /// 服务层 工作时间服务接口
    /// </summary>
    public interface IWrokTimeServices : IServices<string, WorkTimeEntity, WrokTimeDTO>
    {
    }
}
