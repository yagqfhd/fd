using FuDong.Common;
using GanGao.API.Models;
using GanGao.Data.DTO;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace GanGao.API.Controllers
{
    /// <summary>
    /// 权限管理系统之--角色管理，包括添加，删除，查询操作
    /// </summary>    
    [RoutePrefix("Api/Role")]
    [Description("角色管理")]
    public class RoleController : BaseController<string,RoleEntity,RoleDTO,IRoleService<string,RoleEntity>>
    {
        #region ///           属性定义
        //IOC获取角色服务        
        //[Import]
        //IRoleService Service { get; set; }
        #endregion



        #region //            添加
        /// <summary>
        /// API说明：向系统中添加角色，这个操作应该只给管理员操作权限
        /// </summary>
        /// <param name="role">需要添加的角色信息，{Name="角色名称",Description="角色说明"}</param>
        /// <returns>添加角色操作结果信息 
        /// 返回 OK(true)操作成功
        /// 返回 Bad(错误信息)错误失败，其中包含错误信息
        /// </returns>
        [Route("Create"), HttpPost]
        [Description("添加角色")]
        [ResponseType(typeof(ApiResultModel<bool>))]
        public override Task<IHttpActionResult> Create([FromBody] RoleDTO role)
        {
            return base.Create(role);
        }
        /// <summary>
        /// 获取角色列表，这个操作可以
        /// </summary>
        /// <param name="page">获取列表页信息:
        /// {skip=跳过记录数,limit=获取记录数}</param>
        /// <returns>
        /// 获取分页角色列表操作结果信息 
        /// 返回 OK(true)操作成功
        /// 返回 Bad(错误信息)错误失败，其中包含错误信息
        /// </returns>
        [Route("List"), HttpPost]
        [Description("获取角色列表")]
        [ResponseType(typeof(ApiResultModel<PagedResult<RoleDTO>>))]
        public override Task<IHttpActionResult> list([FromBody]QueryPageInput page)
        {
            return base.list(page);
        }

        #endregion
    }
}
