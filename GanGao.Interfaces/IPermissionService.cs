using FuDong.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GanGao.Interfaces
{
    /// <summary>
    /// 服务层 权限信息服务接口
    /// </summary>
    public interface IPermissionService<TKey, TEntity> : IServices<TKey, TEntity>
        where TEntity : EntityBase<TKey>, IDefaultEntity<TKey>
    {
        #region //// 部门相关
        /// <summary>
        /// 是否属于部门
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> InDepartmentAsync(string permissionName, string departmentName);
        /// <summary>
        /// 是否属于部门
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> InDepartmentAsync(TEntity permission, string departmentName);
        /// <summary>
        /// 添加权限到部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> AddDepartmentAsync(string permissionName, string departmentName);
        /// <summary>
        /// 添加权限到部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> AddDepartmentAsync(TEntity permission, string departmentName);
        /// <summary>
        /// 移除权限从部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> RemoveDepartmentAsync(string permissionName, string departmentName);
        /// <summary>
        /// 移除权限从部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> RemoveDepartmentAsync(TEntity permission, string departmentName);
        #endregion

        #region //// 角色相关
        /// <summary>
        /// 是否属于角色
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> IsRoleAsync(string permissionName, string departmentName, string roleName);
        /// <summary>
        /// 是否属于角色
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> IsRoleAsync(TEntity permission, string departmentName, string roleName);
        /// <summary>
        /// 添加角色到权限部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> AddRoleAsync(string permissionName, string departmentName, string roleName);
        /// <summary>
        /// 添加角色到权限部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> AddRoleAsync(TEntity permission, string departmentName, string roleName);
        /// <summary>
        /// 移除角色从权限部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> RemoveRoleAsync(string permissionName, string departmentName, string roleName);
        /// <summary>
        /// 移除角色从权限部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> RemoveRoleAsync(TEntity permission, string departmentName, string roleName);
        #endregion        

        #region /////// 权限验证相关
        /// <summary>
        /// 获取权限具有的权限特征串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetPermissionFlagsAsync(string name);
        /// <summary>
        /// 获取权限具有的权限特征串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetPermissionFlagsAsync(TEntity permission);
        #endregion
    }
}
