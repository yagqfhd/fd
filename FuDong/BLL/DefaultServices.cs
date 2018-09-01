using FuDong.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FuDong.BLL
{
    /// <summary>
    /// 核心业务实现基类
    /// </summary>
    public class DefaultServices<TKey,TEntity, TDTO, TRepository> : IServices<TKey,TEntity, TDTO>
        where TEntity : EntityBase<TKey>, IDefaultEntity<TKey>
        where TDTO : class, IDefaultEntityDTO<TKey>
        where TRepository : IRepository<TKey,TEntity>
    {
        #region ///////////属性
        /// <summary>
        /// 自动保存
        /// </summary>
        public bool AutoSaved { get; set; } = true;
        /// <summary>
        /// 软删除，硬删除
        /// </summary>
        public bool isDeleted { get; set; } = true;
        #endregion

        #region ///////// 服务接口导入
        /// <summary>
        /// 获取或设置 实体信息数据访问对象
        /// </summary>
        [Import]
        protected TRepository Repository { get; set; }
        /// <summary>
        /// 获取或设置 实体信息校验对象
        /// </summary>
        [Import]
        protected IEntityValidator<TEntity> Validator { get; set; }
        /// <summary>
        /// 获取或设置 DTO MODEL 映射服务
        /// </summary>
        [Import]
        protected IDTOMapService DtoMap { get; set; }
        #endregion

        #region ///// 方法实现
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> CreateAsync(TDTO dto)
        {
            //校验参数！=NULL
            Argument.NullParam(dto, dto.GetVarName(li => dto));
            // 实体模型转换
            var obj = DtoMap.Map<TEntity>(dto);
            // 校验实体
            var validateResult = await Validator.ValidateAsync(obj);
            if (validateResult.ResultType != OperationResultType.Success)
                return validateResult;
            // 添加到实体集合中
            Repository.Insert(obj, AutoSaved);
            // 返回正确
            return new OperationResult(OperationResultType.Success);
        }

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> CreateAsync(IEnumerable<TDTO> dtos)
        {
            //校验参数！=NULL
            Argument.NullParam(dtos, dtos.GetVarName(li => dtos));
            // 实体模型转换
            var obj = DtoMap.Map<IEnumerable<TEntity>>(dtos);
            // 校验实体
            var validateResult = await Validator.ValidateAsync(obj);
            if (validateResult.ResultType != OperationResultType.Success)
                return validateResult;
            // 添加到实体集合中
            Repository.Insert(obj, AutoSaved);
            // 返回正确
            return new OperationResult(OperationResultType.Success);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual Task<OperationResult> DeleteAsync(TDTO dto)
        {
            //校验参数！=NULL
            Argument.NullParam(dto, dto.GetVarName(li => dto));
            //// 获取实体
            //var obj = Repository.FindById(dto.Id);

            //if (obj == null)
            //    return Task.FromResult<OperationResult>(
            //        new OperationResult(OperationResultType.Warning,
            //        String.Format(CultureInfo.CurrentCulture,
            //        Resources.NoExist,                    
            //        dto.Name)));
            try
            {
                // 从实体集合删除
                Repository.Delete(dto.Id, isDeleted, AutoSaved);
            }
            catch (DataAccessException ex)
            {
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.Error, ex.Message));
            }
            // 返回正确
            return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual Task<OperationResult> DeleteAsync(object key)
        {
            //校验参数！=NULL
            Argument.NullParam(key, key.GetVarName(li => key));
            
            try
            {
                // 从实体集合删除
                Repository.Delete(key, isDeleted, AutoSaved);
            }
            catch (DataAccessException ex)
            {
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.Error, ex.Message));
            }
            // 返回正确
            return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual Task<OperationResult> DeleteAsync(IEnumerable<TDTO> dtos)
        {
            //校验参数！=NULL
            Argument.NullParam(dtos, dtos.GetVarName(li => dtos));
            var objs = DtoMap.Map<IEnumerable<TEntity>>(dtos);
            try
            {
                // 从实体集合删除
                Repository.Delete(objs, isDeleted, AutoSaved);
            }
            catch (DataAccessException ex)
            {
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.Error, ex.Message));
            }
            // 返回正确
            return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 回复软删除的实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual Task<OperationResult> RestoreAsync(object key)
        {
            //校验参数！=NULL
            Argument.NullParam(key, key.GetVarName(li => key));
            try
            {
                // 从实体集合删除标记回复
                Repository.Restore(key,  AutoSaved);
            }
            catch (DataAccessException ex)
            {
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.Error, ex.Message));
            }
            // 返回正确
            return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> UpdateAsync(TDTO dto)
        {
            //校验参数！=NULL
            Argument.NullParam(dto, dto.GetVarName(li => dto));
            // 获取用户
            var obj = Repository.FindById(dto.Id);
            if (obj == null)
                return new OperationResult(OperationResultType.Warning,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.NoExist,
                    dto.Name));
            // 实体模型转换
            obj = DtoMap.Map<TDTO, TEntity>(dto, obj);
            // 校验实体        
            var validateResult = await Validator.ValidateAsync(obj);
            if (validateResult.ResultType != OperationResultType.Success)
                return validateResult;
            try
            {
                //更新实体
                Repository.Update(obj, AutoSaved);
            }
            catch (DataAccessException ex)
            {
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.Error, ex.Message));
            }
            // 返回正确
            return new OperationResult(OperationResultType.Success);
        }

        /// <summary>
        /// 检查是否存在实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual Task<OperationResult> ExistsAsync(TDTO dto)
        {
            Argument.NullParam(dto, dto.GetVarName(li => dto));
            //获取实体
            var obj = Repository.FindById(dto.Id);
            if (obj == null)
            {
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.NoExist,
                    dto.Name)));
            }
            return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 按照ID获取对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual Task<TDTO> FindByIdAsync(object key)
        {
            Argument.NullParam(key, key.GetVarName(li => key));
            var obj = Repository.FindById(key);
            TDTO result = null;
            if (obj != null)
                result = DtoMap.Map<TDTO>(obj);
            return Task.FromResult<TDTO>(result);
        }

        /// <summary>
        /// 获取分页动态查询
        /// </summary>
        public virtual Task<PagedResult<TDTO>> PageQueryable(int pageSize,int pageNumber,string Order = null, Dictionary<string, string> filter = null)
        {
            var query = Repository.QueryableFilterEntities(filter);
            if (string.IsNullOrEmpty(Order) == false)
                query.OrderBy(Repository.ExpressionOrder<string>(Order));
            var skip = (pageNumber - 1) * pageSize;

            var recs = query.Count();
            var pages = recs / pageSize;
            if (recs % pageSize > 0) pages++;
            if (pageNumber > pages)
                pageNumber = pages;
            //if(pageNumber>pages) // 给定的页号大于最大页码
            //    throw new BusinessException(
            //        String.Format(CultureInfo.CurrentCulture,
            //        Resources.PageError,pages,pageNumber));

            var objs = query.Skip(skip).Take(pageSize).ToList();
            var dtos = DtoMap.Map<List<TDTO>>(objs);
            
            return Task.FromResult<PagedResult<TDTO>>(new PagedResult<TDTO>(recs, pages, pageSize, pageNumber, dtos));
        }
        #endregion
    }
}