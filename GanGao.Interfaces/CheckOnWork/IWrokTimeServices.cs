using FuDong.Common;

namespace GanGao.Interfaces.CheckOnWork
{
    /// <summary>
    /// 服务层 工作时间服务接口
    /// </summary>
    public interface IWrokTimeServices<TKey, TEntity> : IServices<TKey, TEntity>
        where TEntity : EntityBase<TKey>, IDefaultEntity<TKey>
    {
    }
}
