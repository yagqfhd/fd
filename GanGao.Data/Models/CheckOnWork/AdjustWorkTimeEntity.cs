using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models.CheckOnWork
{
    /// <summary>
    /// 调休工作安排
    /// </summary>
    public class AdjustWorkTimeEntity : WorkTimeEntity
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// 是否签到
        /// </summary>
        public bool hasCheckOnWork { get; set; }
        /// <summary>
        /// 调休的原始WorkTimeId号
        /// </summary>
        public string WorkTimeId { get; set; }
    }
}