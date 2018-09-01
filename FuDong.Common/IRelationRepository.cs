using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuDong.Common
{
    /// <summary>
    ///  定义仓储模型中的关联标准操作
    /// </summary>
    public interface IRelationRepository<TKey,TEntity> where TEntity : RelationBase<TKey>
    {
        #region 属性

        /// <summary>
        ///     获取 当前实体的查询数据集 默认返回么有设置删除标志的记录
        /// </summary>
        IQueryable<TEntity> Entities{ get; }

        #endregion

        /// <summary>
        ///     插入实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Insert(TEntity entity, bool isSave = true);

        /// <summary>
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(TEntity entity, bool isSave = true);

        /// <summary>
        ///     查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        TEntity FindById(object key);
    }

}

