using GanGao.Interfaces;
using GanGao.Interfaces.CheckOnWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.BLL.CheckOnWork.Models
{
    /// <summary>
    /// 用户签到输入模型类定义 
    /// </summary>
    public class CheckOnWorkInput : ICheckOnWorkInput
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 签到类型
        /// </summary>
        public QdType QdType { get; set; }
        /// <summary>
        /// 客户IP地址
        /// </summary>
        public string IPAddress { get; set; }
    }
}