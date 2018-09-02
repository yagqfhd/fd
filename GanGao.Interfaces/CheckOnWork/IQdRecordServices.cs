using FuDong.Common;

namespace GanGao.Interfaces.CheckOnWork
{
    /// <summary>
    /// 服务层 签到记录服务接口
    /// </summary>
    public interface IQdRecordServices<TKey,TEntity> : IServices<TKey, TEntity>
        where TEntity : EntityBase<TKey>, IDefaultEntity<TKey>
    {
    }
}
