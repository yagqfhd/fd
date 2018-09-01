using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models
{
    /// <summary>
    /// 用户实体定义
    /// </summary>
    public class UserEntity :DefaultEntity<string>, IDefaultEntity<string>
    {
        #region /////// 数据字段属性定义
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nick { get; set; }
        /// <summary>
        /// 用户联系邮箱
        /// </summary>  
        public string Email { get; set; }
        /// <summary>
        /// 加密保存的密码
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 用户的真实姓名
        /// </summary>
        public string TrueName { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string WX { get; set; }
        #endregion

        /// <summary>
        /// // 用户部门集合 UserDepartment 表中满足条件的集合
        /// </summary>
        public virtual ICollection<UserDepartmentRelation> Departments { get; }

        public UserEntity() : base()
        {
            Id = Guid.NewGuid().ToString();
            Departments = new HashSet<UserDepartmentRelation>();
        }
    }

   
}