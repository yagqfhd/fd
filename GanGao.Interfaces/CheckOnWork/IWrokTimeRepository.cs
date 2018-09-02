using FuDong.Common;

namespace GanGao.Interfaces.CheckOnWork
{
    /// <summary>
    ///     仓储操作接口——工作时间
    /// </summary>
    public interface IWrokTimeRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : EntityBase<TKey>
    {
    }
}
