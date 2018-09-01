using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models.CheckOnWork
{
    /// <summary>
    /// 考勤工作时间表
    /// </summary>
    public class WorkTimeEntity : DefaultEntity<string>, IDefaultEntity<string>
    {
        /// <summary>
        /// 开始时间 0：00 开始的分钟数
        /// </summary>
        public long StartTime { get; set; }
        /// <summary>
        /// 结束时间 0：00 开始的分钟数
        /// </summary>
        public long EndTime { get; set; }
        /// <summary>
        /// 结束时间到后是否允许签到
        /// </summary>
        public bool hasCheckOnWorkEndTimeLast { get; set; } = false;
        /// <summary>
        /// 签到类别
        /// </summary>
        public int QdType { get; set; } = 0;
        /// <summary>
        /// 星期几
        /// </summary>
        public int Week { get; set; } = 0;

        public WorkTimeEntity() : base()
        {
            Id = Guid.NewGuid().ToString();
            Name = Id;
        }
    }
}