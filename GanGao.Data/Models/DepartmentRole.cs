using FuDong.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models
{
    /// <summary>
    /// 权限验证使用的对象
    /// </summary>
    public class DepartmentRole : RelationBase<string>,IDefaultRelation<string>
    {
        public string DepartmentId { get; set; }
        public string RoleId { get; set; }
        /// <summary>
        /// 确定指定的Object是否等于当前的Object。
        /// </summary>
        /// <param name="obj">要与当前对象进行比较的对象。</param>
        /// <returns>如果指定的Object与当前Object相等，则返回true，否则返回false。</returns>
        /// <remarks>有关此函数的更多信息，请参见：http://msdn.microsoft.com/zh-cn/library/system.object.equals。
        /// </remarks>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj == (object)null)
                return false;
            var other = obj as DepartmentRole;
            if (other == (object)null)
                return false;
            return this.DepartmentId.Equals(other.DepartmentId) &&
                this.RoleId.Equals(other.RoleId);
        }
        /// <summary>
        /// 用作特定类型的哈希函数。
        /// </summary>
        /// <returns>当前Object的哈希代码。</returns>
        /// <remarks>有关此函数的更多信息，请参见：http://msdn.microsoft.com/zh-cn/library/system.object.gethashcode。
        /// </remarks>
        public override int GetHashCode()
        {
            return this.DepartmentId.GetHashCode() ^
                this.RoleId.GetHashCode();
        }

        /// <summary>
        /// 确定两个对象是否相等。
        /// </summary>
        /// <param name="a">待确定的第一个对象。</param>
        /// <param name="b">待确定的另一个对象。</param>
        /// <returns>如果两者相等，则返回true，否则返回false。</returns>
        public static bool operator ==(DepartmentRole a, DepartmentRole b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        /// <summary>
        /// 确定两个对象是否不相等。
        /// </summary>
        /// <param name="a">待确定的第一个对象。</param>
        /// <param name="b">待确定的另一个对象。</param>
        /// <returns>如果两者不相等，则返回true，否则返回false。</returns>
        public static bool operator !=(DepartmentRole a, DepartmentRole b)
        {
            return !(a == b);
        }
    }

    
}