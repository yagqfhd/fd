using FuDong.Common;
using FuDong.Data.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanGao.Data.DTO
{
    /// <summary>
    /// 权限DTO
    /// </summary>
    public class PermissionDTO : DefaultEntityDTO<string>, IDefaultEntityDTO<string>
    {
        /// <summary>
        /// API控制器名称
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "PermissionControllerName")]
        public string ControllerName { get; set; }
        /// <summary>
        /// API动作名称（函数名）
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "PermissionActionName")]
        public string ActionName { get; set; }
        /// <summary>
        /// API动作参数
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "PermissionParameters")]
        public string Parameters { get; set; }
        /// <summary>
        /// 权限所属部门
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "PermissionDepartments")]
        public ICollection<RelationDepartmentDTO> Departments { get; set; }
    }
}