using FuDong.Common;
using FuDong.Data.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GanGao.Data.DTO
{
    /// <summary>
    /// 用户DTO
    /// </summary>
    public class UserDTO : DefaultEntityDTO<string>, IDefaultEntityDTO<string>
    {
        /// <summary>
        /// 用户昵称
        /// </summary>
        [Display(ResourceType =typeof(Resources),Name ="UserNick")]
        public string Nick { get; set; }
        /// <summary>
        /// 用户联系邮箱
        /// </summary>  
        [Display(ResourceType = typeof(Resources), Name = "UserEmail")]
        public string Email { get; set; }
        /// <summary>
        /// 加密保存的密码
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "UserPassword")]
        public string Password { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "UserPhoneNumber")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 用户的真实姓名
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "UserTrueName")]
        public string TrueName { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "UserIdCard")]
        public string IdCard { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "UserWX")]
        public string WX { get; set; }
        /// <summary>
        /// 用户所属部门集合
        /// </summary>
        [Display(ResourceType = typeof(Resources), Name = "UserDepartments")]
        public ICollection<RelationDepartmentDTO> Departments { get; set; }

        
    }
}