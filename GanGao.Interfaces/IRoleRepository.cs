using FuDong.Common;

namespace GanGao.Interfaces
{
    /// <summary>
    ///     仓储操作接口——角色信息
    /// </summary>
    public interface IRoleRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : EntityBase<TKey>
    {
    }
}
