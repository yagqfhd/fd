using FuDong.Common;

namespace GanGao.Interfaces
{
    /// <summary>
    ///     仓储操作接口——权限信息
    /// </summary>
    public interface IPermissionRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : EntityBase<TKey>
    {
    }

    /// <summary>
    ///    仓储操作接口——权限部门角色仓储接口
    /// </summary>
    public interface IPermissionDepartmentRepository<TKey, TRelation> : IRelationRepository<TKey, TRelation>
        where TRelation : RelationBase<TKey>
    {
    }
    /// <summary>
    ///    仓储操作接口——权限部门角色仓储接口
    /// </summary>
    public interface IPermissionDepartmentRoleRepository<TKey, TRelation> : IRelationRepository<TKey, TRelation>
        where TRelation : RelationBase<TKey>
    {
    }
}
