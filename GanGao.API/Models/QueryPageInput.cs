using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.API.Models
{

    /// <summary>
    /// 分页查询对象输入参数模型
    /// </summary>
    public class QueryPageInput
    {
        /// <summary>
        /// 跳过记录数
        /// </summary>
        public int skip { get; set; }
        /// <summary>
        /// 获取记录数
        /// </summary>
        public int limit { get; set; }
        /// <summary>
        /// 排序字段名称
        /// </summary>
        public string order { get; set; }
        /// <summary>
        /// 筛选字段名称做Key，筛选的值为Value
        /// </summary>
        public Dictionary<string,string> filter { get; set; }
    }
}