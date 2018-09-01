using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.WX.Models
{
    /// <summary>
    /// 教师微信绑定
    /// </summary>
    public class WXBind
    {
        /// <summary>
        /// 教工号
        /// </summary>
        public string teacher_name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile_phone { get; set; }
        /// <summary>
        /// 微信 OpenID
        /// </summary>
        public string openid { get; set; }
    }
}