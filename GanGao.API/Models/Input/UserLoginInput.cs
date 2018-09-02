using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GanGao.API.Models.Input
{
    /// <summary>
    /// API 用户登录输入参数模型定义
    /// </summary>
    public class UserLoginInput
    {
        [Display(ResourceType = typeof(Resources), Name = "UserName")]
        [Required(ErrorMessageResourceType =typeof(Resources),ErrorMessageResourceName ="Require")]
        [StringLength(20,MinimumLength =3,ErrorMessageResourceType =typeof(Resources),ErrorMessageResourceName = "StringLength")]
        public string UserName { get; set; }
        [Display(ResourceType = typeof(Resources), Name = "Password")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Require")]
        [StringLength(20, MinimumLength = 3, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLength")]
        public string Password { get; set; }
    }
}