using FuDong.Common;

namespace GanGao.Interfaces
{
    /// <summary>
    ///     仓储操作接口——用户仓储操作接口
    /// </summary>
    public interface IUserRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : EntityBase<TKey>
    {
    }

    /// <summary>
    ///    仓储操作接口——用户部门角色仓储接口
    /// </summary>
    public interface IUserDepartmentRepository<TKey, TRelation> : IRelationRepository<TKey, TRelation>
         where TRelation : RelationBase<TKey>
    {
    }
    /// <summary>
    ///     仓储操作接口——用户部门角色仓储接口
    /// </summary>
    public interface IUserDepartmentRoleRepository<TKey, TRelation> : IRelationRepository<TKey, TRelation>
         where TRelation : RelationBase<TKey>
    {
    }
}
