using FuDong.Common;

namespace GanGao.Interfaces.CheckOnWork
{
    /// <summary>
    ///     仓储操作接口——签到记录
    /// </summary>
    public interface IQdRecordRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : EntityBase<TKey>
    {
    }
}
