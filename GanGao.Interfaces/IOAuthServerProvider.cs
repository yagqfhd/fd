using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanGao.Interfaces
{
    /// <summary>
    /// 自定义OAuth服务驱动接口
    /// </summary>
    public interface IOAuthServerProvider : IOAuthAuthorizationServerProvider
    {
    }
}
