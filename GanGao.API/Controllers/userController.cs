using GanGao.API.Models.Input;
using GanGao.Data.DTO;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GanGao.API.Controllers
{
    /// <summary>
    /// 用户相关API
    /// </summary>
    public class userController : BaseController<string,UserEntity,UserDTO,IUserService<string,UserEntity>>
    {
        /// <summary>
        /// 用户登录信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public IHttpActionResult UserLogin([FromBody]UserLoginInput userInfo)
        {
            return Ok();
        }
    }
}
