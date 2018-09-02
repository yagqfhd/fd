using FuDong.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GanGao.Interfaces
{
    /// <summary>
    /// 服务层 用户信息服务接口
    /// </summary>
    public interface IUserService<TKey,TEntity> : IServices<TKey, TEntity>
        where TEntity : EntityBase<TKey> , IDefaultEntity<TKey>
    {        
        #region /// 用户登录相关

        /// <summary>
        /// 校验用户登录名称密码 登录名称包括 用户名，Email ， 身份证，手机号
        /// </summary>
        /// <param name="access"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<OperationResult> ValidatorUserAsync(string access, string password);
        #endregion

        #region //// 用户查询
        /// <summary>
        /// 按照名称查询用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<TEntity> FindByNameAsync(string name);
        /// <summary>
        /// 按照Email查询用户
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<TEntity> FindByEmailAsync(string email);
        /// <summary>
        /// 按照用户身份证查询用户
        /// </summary>
        /// <param name="access"></param>
        /// <returns></returns>
        Task<TEntity> FindByIdCardAsync(string access);
        /// <summary>
        /// 按照用户手机号查询用户
        /// </summary>
        /// <param name="access"></param>
        /// <returns></returns>
        Task<TEntity> FindByPhoneNumberAsync(string access);
        /// <summary>
        /// 按照用户微信查询用户
        /// </summary>
        /// <param name="access"></param>
        /// <returns></returns>
        Task<TEntity> FindByWXAsync(string access);
        #endregion

        #region //// 部门相关
        /// <summary>
        /// 是否属于部门
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> InDepartmentAsync(string userName, string departmentName);
        /// <summary>
        /// 是否属于部门
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> InDepartmentAsync(TEntity user, string departmentName);
        /// <summary>
        /// 添加用户到部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> AddDepartmentAsync(string userName, string departmentName);
        /// <summary>
        /// 添加用户到部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> AddDepartmentAsync(TEntity user, string departmentName);
        /// <summary>
        /// 移除用户从部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> RemoveDepartmentAsync(string userName, string departmentName);
        /// <summary>
        /// 移除用户从部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> RemoveDepartmentAsync(TEntity user, string departmentName);
        #endregion

        #region //// 角色相关
        /// <summary>
        /// 是否属于角色
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> IsRoleAsync(string userName, string departmentName, string roleName);
        /// <summary>
        /// 是否属于角色
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> IsRoleAsync(TEntity user, string departmentName, string roleName);
        /// <summary>
        /// 添加角色到用户部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> AddRoleAsync(string userName, string departmentName, string roleName);
        /// <summary>
        /// 添加角色到用户部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> AddRoleAsync(TEntity user, string departmentName, string roleName);
        /// <summary>
        /// 移除角色从用户部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> RemoveRoleAsync(string userName, string departmentName, string roleName);
        /// <summary>
        /// 移除角色从用户部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        Task<OperationResult> RemoveRoleAsync(TEntity user, string departmentName, string roleName);
        #endregion        

        #region /////// 权限验证相关
        /// <summary>
        /// 获取用户具有的权限特征串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetPermissionFlagsAsync(string name);
        /// <summary>
        /// 获取用户具有的权限特征串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetPermissionFlagsAsync(TEntity user);
        #endregion
    }
}
