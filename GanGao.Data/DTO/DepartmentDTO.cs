using FuDong.Common;
using FuDong.Data.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanGao.Data.DTO
{
    /// <summary>
    /// 部门DTO
    /// </summary>
    public class DepartmentDTO : DefaultEntityDTO<string>, IDefaultEntityDTO<string>
    {
        /// <summary>
        /// 上级部门
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "DepartmentParent")]
        public string Parent { get; set; }
        /// <summary>
        /// 下级部门
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "DepartmentChilds")]
        public ICollection<DepartmentDTO> Childs { get; set; }
    }
}