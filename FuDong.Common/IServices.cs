using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuDong.Common
{
    /// <summary>
    /// 服务层标准建删更新 接口定义
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IServices<TKey,TEntity, TDTO>
        where TEntity : EntityBase<TKey>, IDefaultEntity<TKey>
        where TDTO : class, IDefaultEntityDTO<TKey>
    {
        /// <summary>
        /// 自动保存
        /// </summary>
        bool AutoSaved { get; set; }
        /// <summary>
        /// 软删除，硬删除
        /// </summary>
        bool isDeleted { get; set; }
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<OperationResult> CreateAsync(TDTO entity);
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<OperationResult> CreateAsync(IEnumerable<TDTO> entitys);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<OperationResult> DeleteAsync(object key);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<OperationResult> DeleteAsync(TDTO entity);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<OperationResult> DeleteAsync(IEnumerable<TDTO> entitys);
        /// <summary>
        /// 回复软删除的实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<OperationResult> RestoreAsync(object key);
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<OperationResult> UpdateAsync(TDTO entity);
        /// <summary>
        /// 是否存在实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<OperationResult> ExistsAsync(TDTO entity);
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<TDTO> FindByIdAsync(object id);
        /// <summary>
        /// 分页筛选
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="Order"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<PagedResult<TDTO>> PageQueryable(int pageSize, int pageNumber, string Order = null, Dictionary<string, string> filter = null);


    }
}
