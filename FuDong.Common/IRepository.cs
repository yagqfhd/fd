using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FuDong.Common
{
    /// <summary>
    ///     定义仓储模型中的数据标准操作
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    public interface IRepository<TKey,TEntity> where TEntity : EntityBase<TKey>
    {
        #region 属性

        /// <summary>
        ///     获取 当前实体的查询数据集 默认返回么有设置删除标志的记录
        /// </summary>
        IQueryable<TEntity> Entities(bool isDelete = false); //{ get; }
        
        /// <summary>
        /// 获取Order字段表达式
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="order"></param>
        /// <returns></returns>
        Expression<Func<TEntity, TOrderKey>> ExpressionOrder<TOrderKey>(string order);
        /// <summary>
        /// 获取筛选 Queryable
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IQueryable<TEntity> QueryableFilterEntities(Dictionary<string, string> filter = null,bool isDelete=false);
        #endregion

        #region 公共方法

        /// <summary>
        ///     插入实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Insert(TEntity entity,  bool isSave = true);

        /// <summary>
        ///     批量插入实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Insert(IEnumerable<TEntity> entities,  bool isSave = true);

        /// <summary>
        ///     删除指定编号的记录
        /// </summary>
        /// <param name="id"> 实体记录编号 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(object id, bool isDelete = true, bool isSave = true);

        /// <summary>
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(TEntity entity, bool isDelete = true, bool isSave = true);

        /// <summary>
        ///     删除实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(IEnumerable<TEntity> entities, bool isDelete = true, bool isSave = true);

        /// <summary>
        ///     删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(Expression<Func<TEntity, bool>> predicate, bool isDelete = true, bool isSave = true);

        /// <summary>
        /// 回复软删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        int Restore(object id, bool isSave = true);

        /// <summary>
        /// 回复软删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        int Restore(TEntity entity, bool isSave = true);

        /// <summary>
        ///     更新实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Update(TEntity entity, bool isSave = true);

        /// <summary>
        ///     查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        TEntity FindById(object key);

        /// <summary>
        /// 保存到数据库中
        /// </summary>
        /// <returns></returns>
        int SaveToDataBase();
        #endregion
    }
}
