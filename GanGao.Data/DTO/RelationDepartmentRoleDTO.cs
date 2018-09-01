using FuDong.Common;
using FuDong.Data.DTO;
using System.ComponentModel.DataAnnotations;

namespace GanGao.Data.DTO
{
    /// <summary>
    /// 关联部门角色DTO
    /// </summary>
    public class RelationDepartmentRoleDTO : DefaultRelationDTO<string>, IDefaultRelationDTO<string>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "RoleName")]
        public string Name { get; set; }
    }
}