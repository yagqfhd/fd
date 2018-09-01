using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.API.Models.OAuth
{
    /// <summary>
    /// 微信用户绑定输入信息模型
    /// </summary>
    public class WXCodeToOpenidInput
    {
        public string code { get; set; }
        
    }
}