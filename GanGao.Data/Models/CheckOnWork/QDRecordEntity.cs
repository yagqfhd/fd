using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models.CheckOnWork
{
    
    /// <summary>
    /// 教师签到记录实体
    /// </summary>
    public class QdRecordEntity : DefaultEntity<string>, IDefaultEntity<string>
    {
        /// <summary>
        /// 教师ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 签到开始时间 0：00 开始的分钟数
        /// </summary>
        public long QdTime { get; set; }
        /// <summary>
        /// 签到类别
        /// </summary>
        public int QdType { get; set; }
        /// <summary>
        /// 签到日期
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 对应工作时间ID
        /// </summary>
        public string WorkTimeId { get; set; }
        /// <summary>
        /// 对应工作时间
        /// </summary>
        public virtual WorkTimeEntity WorkTime { get; set; }
        /// <summary>
        /// 签到教师用户
        /// </summary>
        public virtual UserEntity User { get; set; }
    }
}