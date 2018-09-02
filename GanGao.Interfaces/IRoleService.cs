using FuDong.Common;

namespace GanGao.Interfaces
{
    /// <summary>
    /// 服务层 角色信息服务接口
    /// </summary>
    public interface IRoleService<TKey,TEntity> : IServices<TKey, TEntity>
        where TEntity : EntityBase<TKey>, IDefaultEntity<TKey>
    {

    }
}
