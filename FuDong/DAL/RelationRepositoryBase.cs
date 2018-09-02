using FuDong.Common;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;

namespace FuDong.DAL
{
    public class RelationRepositoryBase<TKey,TEntity> : IRelationRepository<TKey,TEntity> where TEntity : RelationBase<TKey>
    {
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
        public virtual IQueryable<TEntity> Entities
        {
            get
            {
                return EFContext.Set<TEntity>();
            }
        }


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
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Delete(TEntity entity,  bool isSave = true)
        {
            Argument.NullParam(entity, entity.GetType().Name);
            EFContext.RegisterDeleted(entity);            
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
    }
}