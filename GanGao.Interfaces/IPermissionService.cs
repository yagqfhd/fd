using FuDong.Common;
using GanGao.Data.DTO;
using GanGao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanGao.Interfaces
{
    /// <summary>
    /// 服务层 权限信息服务接口
    /// </summary>
    public interface IPermissionService : IServices<string, PermissionEntity, PermissionDTO>
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
        Task<OperationResult> InDepartmentAsync(PermissionEntity permission, string departmentName);
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
        Task<OperationResult> AddDepartmentAsync(PermissionEntity permission, string departmentName);
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
        Task<OperationResult> RemoveDepartmentAsync(PermissionEntity permission, string departmentName);
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
        Task<OperationResult> IsRoleAsync(PermissionEntity permission, string departmentName, string roleName);
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
        Task<OperationResult> AddRoleAsync(PermissionEntity permission, string departmentName, string roleName);
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
        Task<OperationResult> RemoveRoleAsync(PermissionEntity permission, string departmentName, string roleName);
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
        Task<IEnumerable<string>> GetPermissionFlagsAsync(PermissionEntity permission);
        #endregion
    }
}
