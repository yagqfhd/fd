using FuDong.Common;
using FuDong.Data.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanGao.Data.DTO
{
    /// <summary>
    /// 关联部门DTO
    /// </summary>
    public class RelationDepartmentDTO : DefaultRelationDTO<string>, IDefaultRelationDTO<string>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "DepartmentName")]
        public string Name { get; set; }
        /// <summary>
        /// 部门中角色
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "DepartmentRole")]
        public ICollection<RelationDepartmentRoleDTO> Roles { get; set; }
    }
}