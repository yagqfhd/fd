using FuDong.Common;

namespace GanGao.Interfaces.CheckOnWork
{
    /// <summary>
    ///     仓储操作接口——调休工作
    /// </summary>
    public interface IAdjustWrokTimeRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : EntityBase<TKey>
    {
    }
}
