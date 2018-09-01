using FuDong.Common;
using GanGao.Data.DTO.CheckOnWork;
using GanGao.Data.Models.CheckOnWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanGao.Interfaces.CheckOnWork
{
    /// <summary>
    /// 教师签到管理服务接口定义
    /// </summary>
    public interface ICheckOnWorkService 
    {
        /// <summary>
        /// 用户签到签离
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<OperationResult> UserCheckOnWorkAsync(string userName);
        /// <summary>
        /// 用户签到
        /// </summary>
        /// <param name="access"></param>
        /// <returns></returns>
        Task<OperationResult> UserSigneInAsync(string access);
        /// <summary>
        /// 用户签离
        /// </summary>
        /// <param name="access"></param>
        /// <returns></returns>
        Task<OperationResult> UserSigneOutAsync(string access);

    }
}
