using FuDong.Common;

namespace GanGao.Interfaces
{
    /// <summary>
    ///     仓储操作接口——部门信息
    /// </summary>
    public interface IDepartmentRepository<TKey,TEntity> : IRepository<TKey, TEntity>
        where TEntity : EntityBase<TKey>
    {
    }
}
