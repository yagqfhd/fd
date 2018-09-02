using FuDong.Common;

namespace GanGao.Interfaces.CheckOnWork
{
    /// <summary>
    /// 服务层 调休工作信息服务接口
    /// </summary>
    public interface IAdjustWrokTimeServices<TKey,TEntity> : IServices<TKey, TEntity>
        where TEntity : EntityBase<TKey>, IDefaultEntity<TKey>
    {
    }
}
