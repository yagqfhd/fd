using FuDong.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace FuDong.DAL
{
    /// <summary>
    ///     EntityFramework仓储操作基类
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    public class RepositoryBase<TKey,TEntity> : IRepository<TKey,TEntity> where TEntity :EntityBase<TKey>
    {
        #region 属性

        /// <summary>
        ///     获取 仓储上下文的实例
        /// </summary>
        [Import]
        public IUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        ///     获取或设置 EntityFramework的数据仓储上下文
        /// </summary>
        protected IUnitOfWorkContext EFContext
        {
            get
            {
                if (UnitOfWork is IUnitOfWorkContext)
                {
                    return UnitOfWork as IUnitOfWorkContext;
                }
                throw new DataAccessException(string.Format(CultureInfo.CurrentCulture, Resources.UnitOfWorkNotIUnitOfWorkContext, UnitOfWork.GetType().Name)); //"数据仓储上下文对象类型不正确，应为IRepositoryContext，实际为 {0}"
            }
        }

        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        public virtual IQueryable<TEntity> Entities(bool isDelete)
        {
            var data = EFContext.Set<TEntity>();
            //if (isDelete)
            //{
            //    var query = data.Where(d => !d.IsDeleted);
            //    return query;
            //}
            var ret = EFContext.Set<TEntity>();
            return ret;//isDelete ? EFContext.Set<TEntity>() : EFContext.Set<TEntity>().Where(d=>d.IsDeleted.Equals(false));
        }

        /// <summary>
        /// 获取Order字段表达式
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="order"></param>
        /// <returns></returns>
        public virtual Expression<Func<TEntity, TOrderKey>> ExpressionOrder<TOrderKey>(string order)
        {
            return LambdaHelper.GetOrderExpression<TEntity, TOrderKey>(order);
        }

        /// <summary>
        /// 获取筛选 Queryable
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> QueryableFilterEntities(Dictionary<string, string> filter = null,bool isDelete= false)
        {
            var query = Entities(isDelete);
            if (filter != null)
            {
                var tmpExpression = LambdaHelper.True<TEntity>();
                foreach (var keyValue in filter)
                {
                    tmpExpression = tmpExpression.And<TEntity>(LambdaHelper.GetContains<TEntity>(keyValue.Key, keyValue.Value));
                }
                query = query.Where(tmpExpression);
            }
            return query;
        }
        #endregion

        #region 公共方法

        /// <summary>
        ///     插入实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Insert(TEntity entity, bool isSave = true)
        {
            Argument.NullParam(entity, entity.GetType().Name);            
            EFContext.RegisterNew(entity);
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     批量插入实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Insert(IEnumerable<TEntity> entities, bool isSave = true)
        {
            Argument.NullParam(entities, entities.GetType().Name);
            EFContext.RegisterNew(entities);
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     删除指定编号的记录
        /// </summary>
        /// <param name="id"> 实体记录编号 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Delete(object id,bool isDelete=true, bool isSave = true)
        {
            Argument.NullParam(id, id.GetType().Name);
            TEntity entity = EFContext.Set<TEntity>().Find(id);
            return entity != null ? Delete(entity,isDelete, isSave) : 0;
        }

        /// <summary>
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Delete(TEntity entity, bool isDelete = true, bool isSave = true)
        {
            Argument.NullParam(entity, entity.GetType().Name);
            if (isDelete) EFContext.RegisterDeleted(entity);
            else // 软删除
            {
                entity.IsDeleted = true;
                EFContext.RegisterModified(entity);
            }
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     删除实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Delete(IEnumerable<TEntity> entities, bool isDelete = true, bool isSave = true)
        {
            Argument.NullParam(entities, entities.GetType().Name);
            if(isDelete)
                EFContext.RegisterDeleted(entities);
            else
            {
                foreach (var entity in entities)
                {
                    entity.IsDeleted = true;
                    EFContext.RegisterModified(entity);
                }                    
            }
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Delete(Expression<Func<TEntity, bool>> predicate, bool isDelete = true, bool isSave = true)
        {
            Argument.NullParam(predicate, predicate.GetType().Name);
            List<TEntity> entities = EFContext.Set<TEntity>().Where(predicate).ToList();
            return entities.Count > 0 ? Delete(entities, isDelete, isSave) : 0;
        }

        /// <summary>
        /// 回复软删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public virtual int Restore(object id, bool isSave = true)
        {
            Argument.NullParam(id, id.GetType().Name);
            TEntity entity = EFContext.Set<TEntity>().Find(id);
            return entity != null ? Restore(entity,  isSave) : 0;
        }

        /// <summary>
        /// 回复软删除记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isSave"></param>
        /// <returns></returns>
        public virtual int Restore(TEntity entity, bool isSave = true)
        {
            Argument.NullParam(entity, entity.GetType().Name);
            entity.IsDeleted =false;
            EFContext.RegisterModified(entity);
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     更新实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Update(TEntity entity, bool isSave = true)
        {
            Argument.NullParam(entity, entity.GetType().Name);
            EFContext.RegisterModified(entity);
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public virtual TEntity FindById(object key)
        {
            Argument.NullParam(key, key.GetType().Name);
            return EFContext.Set<TEntity>().Find(key);
        }

        /// <summary>
        /// 保存到数据库中
        /// </summary>
        /// <returns></returns>
        public virtual int SaveToDataBase()
        {            
            return EFContext.Commit(true);
        }
        #endregion
    }
}