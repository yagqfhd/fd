using FuDong.Common;
using FuDong.Data;
using FuDong.Data.DTO;
using GanGao.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;

namespace GanGao.API.Controllers
{
    public abstract class BaseController<TKey,TEntity, TDTO, TIService> : ApiController
        where TEntity : DefaultEntity<TKey>
        where TDTO : DefaultEntityDTO<TKey>
        where TIService : IServices<TKey,TEntity, TDTO>
    {
        #region ///////// 内部使用方法
        /// <summary>
        /// 获取指定属性
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private object GetProperties(string key)
        {
            object result = null;
            Request.Properties.TryGetValue(key, out result);
            return result;
        }

        /// <summary>
        /// 获取模型验证错误信息
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetModelStateError(ModelStateDictionary status)
        {
            var errstr = status.Keys.AsEnumerable().ExpandAndToString(";");            
            return errstr;
        }
        #endregion


        #region ///           属性定义
        ///IOC获取角色服务        
        [Import]
        TIService Service { get; set; }
        #endregion

        #region //            添加
        /// <summary>
        /// API说明：向系统中添加角色，这个操作应该只给管理员操作权限
        /// </summary>
        /// <param name="entity">需要添加的角色信息，{Name="角色名称",Description="角色说明"}</param>
        /// <returns>添加角色操作结果信息 
        /// 返回 OK(true)操作成功
        /// 返回 Bad(错误信息)错误失败，其中包含错误信息
        /// </returns>
        public virtual async Task<IHttpActionResult> Create([FromBody] TDTO entity)
        {
            #region /// 检查输入信息正确性
            if (!ModelState.IsValid)
                return Ok(new ApiResultModel<bool>(this.GetModelStateError(ModelState)));
            //return BadRequest(this.GetModelStateError(ModelState));
            #endregion
            try
            {
                // 调用服务创建
                var result = await Service.CreateAsync(entity);
                // 根据服务返回值确定返回
                if (result.ResultType == OperationResultType.Success)
                    return Ok(new ApiResultModel<bool>(true));
                return Ok(new ApiResultModel<bool>(result.Message));
            }
            catch (BusinessException ex)
            {
                return Ok(new ApiResultModel<bool>(ex.Message));
            }
            catch (ComponentException ex)
            {
                return Ok(new ApiResultModel<bool>(ex.Message));
            }
        }
        #endregion

        #region ///////  查询
        public virtual  async Task<IHttpActionResult> list([FromBody]QueryPageInput page)
        {
            #region /// 检查输入信息正确性
            if (!ModelState.IsValid)
                return Ok(new ApiResultModel<PagedResult<TDTO>>(this.GetModelStateError(ModelState)));
            #endregion
            try
            {
                var result = await Service.PageQueryable(page.skip, page.limit,page.order,page.filter);
                return Ok(new ApiResultModel<PagedResult<TDTO>>(result));
            }
            catch(DataAccessException ex)
            {
                return Ok(new ApiResultModel<PagedResult<TDTO>>(ex.Message));
            }
            catch (BusinessException ex)
            {
                return Ok(new ApiResultModel<PagedResult<TDTO>>(ex.Message));
            }
            catch (ComponentException ex)
            {
                return Ok(new ApiResultModel<PagedResult<TDTO>>(ex.Message));
            }
        }
        #endregion

        #region ///   删除
        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> remove(string name)
        {
            #region /// 检查输入信息正确性
            if(string.IsNullOrWhiteSpace(name))            
                return Ok(new ApiResultModel<bool>(string.Format(CultureInfo.CurrentCulture,Resources.ParaError)));
            #endregion

            try
            {
                // 调用服务创建用户
                var result = await Service.DeleteAsync(name);
                // 根据服务返回值确定返回
                if (result.ResultType == OperationResultType.Success)
                    return Ok(true);
                return Ok(new ApiResultModel<bool>(result.Message));
            }
            catch (BusinessException ex)
            {
                return Ok(new ApiResultModel<bool>(ex.Message));

            }
            catch (ComponentException ex)
            {
                return Ok(new ApiResultModel<bool>(ex.Message));
            }
        }
        #endregion
    }

}
