using FuDong.Common;

namespace GanGao.Interfaces
{
    /// <summary>
    /// 服务层 部门信息服务接口
    /// </summary>
    public interface IDepartmentService<TKey, TEntity> : IServices<TKey, TEntity>
        where TEntity : EntityBase<TKey>, IDefaultEntity<TKey>
    {

    }
}
