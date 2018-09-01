using GanGao.WX.Models;
using GanGao.WX.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GanGao.WX.Controllers
{
    public class WXController : ApiController
    {
        public virtual Task<IHttpActionResult> WX_Bind([FromBody] WXBind input)
        {
            Console.WriteLine("token:{0}", "WX_Bind");
            return Task.FromResult<IHttpActionResult>(Ok(ApiResult<bool>.Success(true)));
        }
        public virtual Task<IHttpActionResult> WX_Code_Open_Id([FromBody] WXCode code)
        {
            Console.WriteLine("code:{0}", code.code);
            var token = WXHelper.Get_token(code.code);
            Console.WriteLine("token:{0}", token);
            return Task.FromResult<IHttpActionResult>(Ok(ApiResult<string>.Success(token)));
        }

        
    }
}
