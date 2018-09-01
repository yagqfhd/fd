using System;

namespace FuDong.Common
{
    /// <summary>
    ///     类型扩展方法类
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        ///     判断指定类型是否为数值类型
        /// </summary>
        /// <param name="type">要检查的类型</param>
        /// <returns>是否是数值类型</returns>
        public static bool IsNumeric(this Type type)
        {
            return type == typeof(Byte)
                || type == typeof(Int16)
                || type == typeof(Int32)
                || type == typeof(Int64)
                || type == typeof(SByte)
                || type == typeof(UInt16)
                || type == typeof(UInt32)
                || type == typeof(UInt64)
                || type == typeof(Decimal)
                || type == typeof(Double)
                || type == typeof(Single);
        }

        /// <summary>
        /// 扩展 获取变量名称(字符串)
        /// </summary>
        /// <param name="var_name"></param>
        /// <param name="exp"></param>
        /// <returns>return string</returns>
        public static string GetVarName<T>(this T var_name, System.Linq.Expressions.Expression<Func<T, T>> exp)
        {
            return ((System.Linq.Expressions.MemberExpression)exp.Body).Member.Name;
        }
    }
}