using FuDong.BLL;
using FuDong.Common;
using FuDong.Password;
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
    /// 用户服务层
    /// </summary>
    [Export(typeof(IUserService<string,UserEntity>))]
    public class UserService : DefaultServices<string, UserEntity,IUserRepository<string, UserEntity>>, IUserService<string, UserEntity>
    {
        #region ////////////受保护的属性
        /// <summary>
        /// 部门信息存储访问对象
        /// </summary>
        [Import]
        protected IDepartmentRepository<string,DepartmentEntity> departmentRepository { get; set; }
        /// <summary>
        /// 角色信息存储访问对象
        /// </summary>
        [Import]
        protected IRoleRepository<string, RoleEntity> roleRepository { get; set; }
        ///// <summary>
        ///// 获取或设置 用户信息校验对象
        ///// </summary>
        //[Import]
        //IValidator<SysUser> Validator { get; set; }

        ///// <summary>
        ///// 获取或设置 DTO MODEL 映射服务
        ///// </summary>
        //[Import]
        //IDtoMapService DtoMap { get; set; }

        /// <summary>
        /// 密码校验生成对象
        /// </summary>
        [Import]
        private IPasswordValidator _passwordValidator = new DefaultPasswordValidator();        
        #endregion

        #region 方法实现

        #region ////// 登录相关
        /// <summary>
        /// 校验用户名称密码
        /// </summary>
        /// <param name="access"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual Task<OperationResult> ValidatorUserAsync(string access, string password)
        {
            Argument.NullOrEmpty(access, "access");
            Argument.NullOrEmpty(password, "password");
            // 获取用户
            var query = Repository.Entities(isDeleted);
            var user = query.SingleOrDefault(m => m.Name == access || m.Email == access);
            if (user == null)
            {
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNoExist
                    , access)));
            }
            //校验密码
            if (_passwordValidator.VerifyHashedPassword(user.PasswordHash, password))
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.Success));
            return Task.FromResult<OperationResult>(
                new OperationResult(OperationResultType.QueryNull,
                String.Format(CultureInfo.CurrentCulture,
                    Resources.PasswordError)));
        }
        #endregion

        #region /////// 查询
        
        /// <summary>
        /// 按照名称查询用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual Task<UserEntity> FindByNameAsync(string name)
        {
            Argument.NullOrEmpty(name, "name");
            var user = Repository.Entities().SingleOrDefault(m => m.Name.Equals(name));
            if (user == null)
            {
                return Task.FromResult<UserEntity>(null);
            }
            return Task.FromResult<UserEntity>(user);
        }
        /// <summary>
        /// 按照Email查询用户
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public virtual Task<UserEntity> FindByEmailAsync(string email)
        {
            Argument.NullOrEmpty(email, "email");
            var user = Repository.Entities().SingleOrDefault(m => m.Email.Equals(email));
            if (user == null)
            {
                return Task.FromResult<UserEntity>(null);
            }
            return Task.FromResult<UserEntity>(user);
        }
        /// <summary>
        /// 按照用户名身份证查询用户
        /// </summary>
        /// <param name="idCard"></param>
        /// <returns></returns>
        public virtual Task<UserEntity> FindByIdCardAsync(string idCard)
        {
            Argument.NullOrEmpty(idCard, "IdCard");
            var user = Repository.Entities().SingleOrDefault(m => m.IdCard.Equals(idCard));
            if (user == null)
            {
                return Task.FromResult<UserEntity>(null);
            }
            //var UserDTO = DtoMap.Map<UserDTO>(user);
            return Task.FromResult<UserEntity>(user);
        }
        /// <summary>
        /// 根据用户手机号查询用户
        /// </summary>
        /// <param name="access"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual Task<UserEntity> FindByPhoneNumberAsync(string phoneNumber)
        {
            Argument.NullOrEmpty(phoneNumber, "phoneNumber");            
            // 获取用户
            var user = Repository.Entities().SingleOrDefault(m => m.PhoneNumber.Equals(phoneNumber));
            if (user == null)
            {
                return Task.FromResult<UserEntity>(null);
            }
            return Task.FromResult<UserEntity>(user);
        }
        /// <summary>
        /// 根据用户微信查询用户
        /// </summary>
        /// <param name="access"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual Task<UserEntity> FindByWXAsync(string wx)
        {
            Argument.NullOrEmpty(wx, "phoneNumber");
            // 获取用户
            var user = Repository.Entities().SingleOrDefault(m => m.WX.Equals(wx));
            if (user == null)
            {
                return Task.FromResult<UserEntity>(null);
            }
            return Task.FromResult<UserEntity>(user);
        }
        #endregion

        #region //// 部门相关增删改
        /// <summary>
        /// 是否属于部门
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> InDepartmentAsync(string userName, string departmentName)
        {
            Argument.NullOrEmpty(userName, "userName");
            var user = Repository.Entities().FirstOrDefault(d => d.Name.Equals(userName));
            if (user == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNoExist
                    , userName)));
            return await InDepartmentAsync(user, departmentName);
        }
        
        /// <summary>
        /// 是否属于部门
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> InDepartmentAsync(UserEntity user, string departmentName)
        {
            Argument.NullParam(user, "user");
            ///获取部门
            var department = departmentRepository.Entities().FirstOrDefault(d => d.Name.Equals(departmentName));
            if (department == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.DepartmentNotExist
                    , departmentName)));
            //检查用户是否包含部门
            var userDepartment = user.Departments.FirstOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (userDepartment != null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserInDepartment,
                    user, departmentName)));
            return await Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }
        
        /// <summary>
        /// 添加用户到部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual  async Task<OperationResult> AddDepartmentAsync(string userName, string departmentName)
        {
            Argument.NullOrEmpty(userName,"userName");
            ///获取用户
            var user = Repository.Entities().FirstOrDefault(d => d.Name.Equals(userName));
            if (user == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNoExist
                    , userName)));
            return await AddDepartmentAsync(user, departmentName);
        }

        /// <summary>
        /// 添加用户到部门中
        /// </summary>
        /// <param name="user"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> AddDepartmentAsync(UserEntity user, string departmentName)
        {
            Argument.NullParam(user, "user");
            //if (user == null)
            //    return await Task.FromResult<OperationResult>(
            //        new OperationResult(OperationResultType.ParamError,
            //        String.Format(CultureInfo.CurrentCulture,
            //        Resources.UserNoExist
            //        , user)));
            ///获取部门
            var department = departmentRepository.Entities().FirstOrDefault(d => d.Name.Equals(departmentName));
            if (department == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.DepartmentNotExist
                    , departmentName)));
            //检查用户是否包含部门
            var userDepartment = user.Departments.FirstOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (userDepartment != null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserInDepartment,
                    user, departmentName)));
            ///添加部门
            try
            {  /// 说明，这个只是在内存中添加，实际应该保存到数据库中
                user.Departments.Add(new UserDepartmentRelation { UserId = user.Id, DepartmentId = department.Id });
            }
            catch (DataAccessException ex)
            {
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.Error, ex.Message));
            }
            return await Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 移除用户从部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual Task<OperationResult> RemoveDepartmentAsync(string userName, string departmentName)
        {
            Argument.NullOrEmpty(userName, "userName");
            ///获取用户
            var user = Repository.Entities().FirstOrDefault(d => d.Name.Equals(userName));
            if (user == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNoExist
                    , userName)));
            return  AddDepartmentAsync(user, departmentName);
        }

        /// <summary>
        /// 移除用户从部门中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual Task<OperationResult> RemoveDepartmentAsync(UserEntity user, string departmentName)
        {
            Argument.NullParam(user, "user");
            ///获取用户
            //var user = Repository.Entities.FirstOrDefault(d => d.Name.Equals(userName));
            //if (user == null)
            //    return Task.FromResult<OperationResult>(
            //        new OperationResult(OperationResultType.ParamError,
            //        String.Format(CultureInfo.CurrentCulture,
            //        Resources.UserNoExist
            //        , userName)));
            ///获取部门
            var department = departmentRepository.Entities().FirstOrDefault(d => d.Name.Equals(departmentName));
            if (department == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.DepartmentNotExist
                    , departmentName)));
            //检查用户是否包含部门
            var userDepartment = user.Departments.FirstOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (userDepartment == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNotInDepartment,
                    user.Name, departmentName)));
            //user.Departments.Remove(.FirstOrDefault(d => d.Department.Name.Equals(departmentName));
            ///移除部门
            try
            {
                user.Departments.Remove(new UserDepartmentRelation { UserId = user.Id, DepartmentId = department.Id });
                //UserDepartmentRepository.Delete(userDepartment, AutoSaved);
            }
            catch (NotSupportedException)
            {
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNotInDepartment,
                    user.Name, departmentName)));
            }
            return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }
        #endregion

        #region //// 角色相关
        /// <summary>
        /// 是否属于部门角色
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> IsRoleAsync(string userName, string departmentName, string roleName)
        {
            Argument.NullOrEmpty(userName, "userName");
            var user = Repository.Entities().FirstOrDefault(d => d.Name.Equals(userName));
            if (user == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNoExist
                    , userName)));
            return await IsRoleAsync(user, departmentName, roleName);
        }

        /// <summary>
        /// 是否属于部门角色
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public virtual async Task<OperationResult> IsRoleAsync(UserEntity user, string departmentName, string roleName)
        {
            Argument.NullParam(user, "user");
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
            // 校验用户部门
            var userDepartment = user.Departments.SingleOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (userDepartment == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.UserNotInDepartment,
                    user.Name, department.Name)));
            ///校验用户部门角色
            var userDepartmentRole = userDepartment.Roles.SingleOrDefault(d => d.RoleId.Equals(role.Id));
            if (userDepartmentRole == null)
                return await Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.UserInRole,
                    user.Name, department.Name, role.Name)));

            return await Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 添加用户到部门角色中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Task<OperationResult> AddRoleAsync(string userName, string departmentName, string roleName)
        {
            Argument.NullOrEmpty(userName, "userName");
            ///获取用户
            var user = Repository.Entities().FirstOrDefault(d => d.Name.Equals(userName));
            if (user == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNoExist
                    , userName)));
            return AddRoleAsync(user, departmentName,roleName);
        }
        
        /// <summary>
        /// 添加用户到部门角色中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Task<OperationResult> AddRoleAsync(UserEntity user, string departmentName, string roleName)
        {
            Argument.NullParam(user, "user");
            ///获取用户
            //var user = Repository.Entities.FirstOrDefault(d => d.Name.Equals(userName));
            if (user == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNoExist
                    , user.Name)));
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
            // 校验用户部门
            var userDepartment = user.Departments.SingleOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (userDepartment == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.UserNotInDepartment,
                    user.Name,department.Name)));
            ///校验用户部门角色
            var userDepartmentRole = userDepartment.Roles.SingleOrDefault(d => d.RoleId.Equals(role.Id));
            if (userDepartmentRole != null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.UserInRole,
                    user.Name,department.Name,role.Name)));
            ///保存            
            try
            {
                userDepartment.Roles.Add(new UserDepartmentRoleRelation {
                    UserId = user.Id,
                    DepartmentId = department.Id,
                    RoleId = role.Id
                });
                Repository.SaveToDataBase();
                //UserDepartmentRoleRepository.Insert(new UserDepartmentRole
                //{
                //    UserId = user.Id,
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
        
        /// <summary>
        /// 移除用户从部门角色中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Task<OperationResult> RemoveRoleAsync(string userName, string departmentName, string roleName)
        {
            Argument.NullOrEmpty(userName, "userName");
            ///获取用户
            var user = Repository.Entities().FirstOrDefault(d => d.Name.Equals(userName));
            if (user == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNoExist
                    , userName)));
            return RemoveRoleAsync(user, departmentName, roleName);
        }
        
        /// <summary>
        /// 移除用户从部门角色中
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Task<OperationResult> RemoveRoleAsync(UserEntity user, string departmentName, string roleName)
        {
            Argument.NullOrEmpty(departmentName, "departmentName");
            Argument.NullOrEmpty(roleName, "roleName");
            ///获取用户
            //var user = Repository.Entities.FirstOrDefault(d => d.Name.Equals(userName));
            if (user == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.ParamError,
                    String.Format(CultureInfo.CurrentCulture,
                    Resources.UserNoExist
                    , user.Name)));
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
            // 校验用户部门
            var userDepartment = user.Departments.SingleOrDefault(d => d.DepartmentId.Equals(department.Id));
            if (userDepartment == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.UserNotInDepartment,
                    user.Name, department.Name)));
            ///校验用户部门角色
            var userDepartmentRole = userDepartment.Roles.SingleOrDefault(d => d.RoleId.Equals(role.Id));
            if (userDepartmentRole == null)
                return Task.FromResult<OperationResult>(
                    new OperationResult(OperationResultType.QueryNull,
                    string.Format(CultureInfo.CurrentCulture,
                    Resources.UserNotInRole,
                    user.Name, department.Name, role.Name)));
            ///保存            
            try
            {
                userDepartment.Roles.Remove(userDepartmentRole);
                Repository.SaveToDataBase();
                //UserDepartmentRoleRepository.Insert(new UserDepartmentRole
                //{
                //    UserId = user.Id,
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
        /// 获取用户具有的权限特征串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual Task<IEnumerable<string>> GetPermissionFlagsAsync(string name)
        {
            Argument.NullOrEmpty(name, "userName");
            // 获取用户
            var user = Repository.Entities().FirstOrDefault(d => d.Name.Equals(name));
            if (user == null) return Task.FromResult<IEnumerable<string>>(new List<string>());
            return GetPermissionFlagsAsync(user);
        }
        /// <summary>
        /// 获取用户具有的权限特征串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual Task<IEnumerable<string>> GetPermissionFlagsAsync(UserEntity user)
        {
            if (user == null)
                return Task.FromResult<IEnumerable<string>>(new List<string>());
            var result = new List<string>();
            foreach (var dep in user.Departments)
            {
                result.AddRange(dep.Roles.Select(d => string.Format("{0}{1}", d.DepartmentId, d.RoleId)));
            }
            return Task.FromResult<IEnumerable<string>>(result);
        }
        #endregion

        #endregion


    }
}