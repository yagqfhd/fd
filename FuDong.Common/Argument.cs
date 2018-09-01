using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FuDong.Common
{
    /// <summary>
    /// 通用参数检查类
    /// </summary>
    public static class Argument
    {
        /// <summary>
        /// 检查字符串是空的或空的，并抛出一个异常
        /// </summary>
        /// <param name="val">值测试</param>
        /// <param name="paramName">参数检查名称</param>
        public static void NullOrEmpty(string val, string paramName)
        {
            if (string.IsNullOrEmpty(val))
                throw new ArgumentNullException(paramName, string.Format(CultureInfo.CurrentCulture,Resources.IsNullOrEmpty,paramName));
        }

        /// <summary>
        /// 检查参数不是无效，并抛出一个异常
        /// </summary>
        /// <param name="param">检查值</param>
        /// <param name="paramName">参数名称</param>
        public static void NullParam(object param, string paramName)
        {            
            if (param == null)
                throw new ArgumentNullException(paramName, string.Format(CultureInfo.CurrentCulture, Resources.IsNull,paramName));
        }

        /// <summary>
        /// 请检查参数1不同于参数2
        /// </summary>
        /// <param name="param1">值1测试</param>
        /// <param name="param1Name">name of value 1</param>
        /// <param name="param2">value 2 to test</param>
        /// <param name="param2Name">name of vlaue 2</param>
        public static void DifferentsParams(object param1, string param1Name, object param2, string param2Name)
        {
            if (param1 == param2)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Differents, param1Name, param2Name));
            }
        }

        /// <summary>
        /// 检查一个整数值是正的（>0）
        /// </summary>
        /// <param name="val">整数测试</param>
        public static void PositiveValue(int val,string paramName)
        {
            if (val <= 0)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Positive, paramName), paramName);
        }
    }
}