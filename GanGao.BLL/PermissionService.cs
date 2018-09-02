using FuDong.BLL;
using FuDong.Common;
using FuDong.Password;
using GanGao.Data.DTO;
using GanGao.Data.Models;
using GanGao.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GanGao.BLL
{
    /// <summary>
    /// 权限服务层
    /// </summary>
    [Export(typeof(IPermissionService<string, PermissionEntity>))]
    public class PermissionService : 
        DefaultServices<string, PermissionEntity,  IPermissionRepository<string, PermissionEntity>>, 
        IPermissionService<string, PermissionEntity>
    {
        #region ////////////受保护的属性
        /// <summary>
        /// 部门信息存储访问对象
        /// </summary>
        [Import]
        protected IDepartmentRepository<string, DepartmentEntity> departmentRepository { get; set; }
        /// <summary>
        /// 角色信息存储访问对象
        /// </summary>
        [Import]
        protected IRoleRepository<string, RoleEntity> roleRepository { get; set; }
        #endregion

        #region //// 部门相关增删改
        /// <summary>
        /// 是否属于部门
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> InDepartmentAsync(string permissionName, string departmentName)
        {
            Argument.NullOrEmpty(permissionName, "permissionName");
            var permission = Repository.Entities().FirstOrDefault(d => d.Name.Equals(permissionName));
            if (permission == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotExist
                    , permissionName)));
            return await InDepartmentAsync(permission, departmentName);
        }

        /// <summary>
        /// 是否属于部门
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> InDepartmentAsync(PermissionEntity permission, string departmentName)
        {
            Argument.NullParam(permission, "permission");
            ///获取部门
            var department = departmentRepository.Entities().FirstOrDefault(d => d.Name.Equals(departmentName));
            if (department == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.DepartmentNotExist
                    , departmentName)));
            //检查权限是否包含部门
            var permissionDepartment = permission.Departments.FirstOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (permissionDepartment != null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionInDepartment,
                    permission, departmentName)));
            return await Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 添加权限到部门中
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> AddDepartmentAsync(string permissionName, string departmentName)
        {
            Argument.NullOrEmpty(permissionName, "permissionName");
            ///获取权限
            var permission = Repository.Entities().FirstOrDefault(d => d.Name.Equals(permissionName));
            if (permission == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotExist, permissionName)));
            return await AddDepartmentAsync(permission, departmentName);
        }

        /// <summary>
        /// 添加权限到部门中
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> AddDepartmentAsync(PermissionEntity permission, string departmentName)
        {
            Argument.NullParam(permission, "permission");
            //if (permission == null)
            //    return await Task.FromResult<OperationResult>(
            //        new OperationResult(OperationResultType.ParamError,
            //        String.Format(CultureInfo.CurrentCulture,
            //        Resources.PermissionNoExist
            //        , permission)));
            ///获取部门
            var department = departmentRepository.Entities().FirstOrDefault(d => d.Name.Equals(departmentName));
            if (department == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.DepartmentNotExist
                    , departmentName)));
            //检查权限是否包含部门
            var permissionDepartment = permission.Departments.FirstOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (permissionDepartment != null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionInDepartment,
                    permission, departmentName)));
            ///添加部门
            try
            {  /// 说明，这个只是在内存中添加，实际应该保存到数据库中
                permission.Departments.Add(new PermissionDepartmentRelation { PermissionId = permission.Id, DepartmentId = department.Id });
            }
            catch (DataAccessException ex)
            {
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.Error, ex.Message));
            }
            return await Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 移除权限从部门中
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual Task<OperationResult> RemoveDepartmentAsync(string permissionName, string departmentName)
        {
            Argument.NullOrEmpty(permissionName, "permissionName");
            ///获取权限
            var permission = Repository.Entities().FirstOrDefault(d => d.Name.Equals(permissionName));
            if (permission == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotExist
                    , permissionName)));
            return AddDepartmentAsync(permission, departmentName);
        }

        /// <summary>
        /// 移除权限从部门中
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual Task<OperationResult> RemoveDepartmentAsync(PermissionEntity permission, string departmentName)
        {
            Argument.NullParam(permission, "permission");            
            ///获取部门
            var department = departmentRepository.Entities().FirstOrDefault(d => d.Name.Equals(departmentName));
            if (department == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.DepartmentNotExist
                    , departmentName)));
            //检查权限是否包含部门
            var permissionDepartment = permission.Departments.FirstOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (permissionDepartment == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotInDepartment,
                    permission.Name, departmentName)));            
            ///移除部门
            try
            {
                permission.Departments.Remove(new PermissionDepartmentRelation { PermissionId = permission.Id, DepartmentId = department.Id });
                //PermissionDepartmentRepository.Delete(permissionDepartment, AutoSaved);
            }
            catch (NotSupportedException)
            {
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotInDepartment,
                    permission.Name, departmentName)));
            }
            return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }
        #endregion

        #region //// 角色相关
        /// <summary>
        /// 是否属于部门角色
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> IsRoleAsync(string permissionName, string departmentName, string roleName)
        {
            Argument.NullOrEmpty(permissionName, "permissionName");
            var permission = Repository.Entities().FirstOrDefault(d => d.Name.Equals(permissionName));
            if (permission == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotExist
                    , permissionName)));
            return await IsRoleAsync(permission, departmentName, roleName);
        }

        /// <summary>
        /// 是否属于部门角色
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> IsRoleAsync(PermissionEntity permission, string departmentName, string roleName)
        {
            Argument.NullParam(permission, "permission");
            Argument.NullOrEmpty(roleName, "roleName");
            Argument.NullOrEmpty(departmentName, "departmentName");
            ///获取部门
            var department = departmentRepository.Entities().FirstOrDefault(d => d.Name.Equals(departmentName));
            if (department == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.DepartmentNotExist
                    , departmentName)));
            //获取角色
            var role = roleRepository.Entities().FirstOrDefault(d => d.Name.Equals(roleName));
            if (role == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.RoleNotExist
                    , roleName)));
            // 校验权限部门
            var permissionDepartment = permission.Departments.SingleOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (permissionDepartment == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotInDepartment,
                    permission.Name, department.Name)));
            ///校验权限部门角色
            var permissionDepartmentRole = permissionDepartment.Roles.SingleOrDefault(d => d.RoleId.Equals(role.Id));
            if (permissionDepartmentRole == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionInRole,
                    permission.Name, department.Name, role.Name)));

            return await Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 添加权限到部门角色中
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Task<OperationResult> AddRoleAsync(string permissionName, string departmentName, string roleName)
        {
            Argument.NullOrEmpty(permissionName, "permissionName");
            ///获取权限
            var permission = Repository.Entities().FirstOrDefault(d => d.Name.Equals(permissionName));
            if (permission == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotExist
                    , permissionName)));
            return AddRoleAsync(permission, departmentName, roleName);
        }

        /// <summary>
        /// 添加权限到部门角色中
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Task<OperationResult> AddRoleAsync(PermissionEntity permission, string departmentName, string roleName)
        {
            Argument.NullParam(permission, "permission");
            ///获取权限
            //var permission = Repository.Entities.FirstOrDefault(d => d.Name.Equals(permissionName));
            if (permission == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotExist
                    , permission.Name)));
            ///获取部门
            var department = departmentRepository.Entities().FirstOrDefault(d => d.Name.Equals(departmentName));
            if (department == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.DepartmentNotExist
                    , departmentName)));
            //获取角色
            var role = roleRepository.Entities().FirstOrDefault(d => d.Name.Equals(roleName));
            if (role == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.RoleNotExist
                    , roleName)));
            // 校验权限部门
            var permissionDepartment = permission.Departments.SingleOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (permissionDepartment == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotInDepartment,
                    permission.Name, department.Name)));
            ///校验权限部门角色
            var permissionDepartmentRole = permissionDepartment.Roles.SingleOrDefault(d => d.RoleId.Equals(role.Id));
            if (permissionDepartmentRole != null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionInRole,
                    permission.Name, department.Name, role.Name)));
            ///保存            
            try
            {
                permissionDepartment.Roles.Add(new PermissionDepartmentRoleRelation
                {
                    PermissionId = permission.Id,
                    DepartmentId = department.Id,
                    RoleId = role.Id
                });
                Repository.SaveToDataBase();                
            }
            catch (DataAccessException ex)
            {
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.Error, ex.Message));
            }

            //成功
            return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 移除权限从部门角色中
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Task<OperationResult> RemoveRoleAsync(string permissionName, string departmentName, string roleName)
        {
            Argument.NullOrEmpty(permissionName, "permissionName");
            ///获取权限
            var permission = Repository.Entities().FirstOrDefault(d => d.Name.Equals(permissionName));
            if (permission == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotExist
                    , permissionName)));
            return RemoveRoleAsync(permission, departmentName, roleName);
        }

        /// <summary>
        /// 移除权限从部门角色中
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Task<OperationResult> RemoveRoleAsync(PermissionEntity permission, string departmentName, string roleName)
        {
            Argument.NullOrEmpty(departmentName, "departmentName");
            Argument.NullOrEmpty(roleName, "roleName");
            ///获取权限
            //var permission = Repository.Entities.FirstOrDefault(d => d.Name.Equals(permissionName));
            if (permission == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotExist
                    , permission.Name)));
            ///获取部门
            var department = departmentRepository.Entities().FirstOrDefault(d => d.Name.Equals(departmentName));
            if (department == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.DepartmentNotExist
                    , departmentName)));
            //获取角色
            var role = roleRepository.Entities().FirstOrDefault(d => d.Name.Equals(roleName));
            if (role == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.RoleNotExist
                    , roleName)));
            // 校验权限部门
            var permissionDepartment = permission.Departments.SingleOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (permissionDepartment == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotInDepartment,
                    permission.Name, department.Name)));
            ///校验权限部门角色
            var permissionDepartmentRole = permissionDepartment.Roles.SingleOrDefault(d => d.RoleId.Equals(role.Id));
            if (permissionDepartmentRole == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.PermissionNotInRole,
                    permission.Name, department.Name, role.Name)));
            ///保存            
            try
            {
                permissionDepartment.Roles.Remove(permissionDepartmentRole);
                Repository.SaveToDataBase();
                //PermissionDepartmentRoleRepository.Insert(new PermissionDepartmentRole
                //{
                //    PermissionId = permission.Id,
                //    DepartmentId = department.Id,
                //    RoleId = role.Id
                //}, AutoSaved);
            }
            catch (DataAccessException ex)
            {
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.Error, ex.Message));
            }
            //成功
            return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }
        #endregion

        #region //////权限验证相关
        /// <summary>
        /// 获取权限具有的权限特征串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual Task<IEnumerable<string>> GetPermissionFlagsAsync(string name)
        {
            Argument.NullOrEmpty(name, "permissionName");
            // 获取权限
            var permission = Repository.Entities().FirstOrDefault(d => d.Name.Equals(name));
            if (permission == null) return Task.FromResult<IEnumerable<string>>(new List<string>());
            return GetPermissionFlagsAsync(permission);
        }
        /// <summary>
        /// 获取权限具有的权限特征串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual Task<IEnumerable<string>> GetPermissionFlagsAsync(PermissionEntity permission)
        {
            if (permission == null)
                return Task.FromResult<IEnumerable<string>>(new List<string>());
            var result = new List<string>();
            foreach (var dep in permission.Departments)
            {
                result.AddRange(dep.Roles.Select(d => string.Format("{0}{1}", d.DepartmentId, d.RoleId)));
            }
            return Task.FromResult<IEnumerable<string>>(result);
        }
        #endregion
    }
}