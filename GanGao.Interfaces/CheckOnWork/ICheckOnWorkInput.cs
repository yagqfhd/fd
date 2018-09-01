using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanGao.Interfaces.CheckOnWork
{
    /// <summary>
    /// 教师签到输入模型接口
    /// </summary>
    public interface ICheckOnWorkInput
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        string UserName { get; set; }
        /// <summary>
        /// 签到类型
        /// </summary>
        QdType QdType { get; set; }
        /// <summary>
        /// 客户IP地址
        /// </summary>
        string IPAddress { get; set; }

    }
}
