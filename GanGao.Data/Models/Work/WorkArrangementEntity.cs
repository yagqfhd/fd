using FuDong.Common;
using FuDong.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GanGao.Data.Models.Work
{
    /// <summary>
    /// 工作安排实体
    /// </summary>
    public class WorkArrangementEntity : DefaultEntity<string>, IDefaultEntity<string>
    {
        /// <summary>
        /// 工作安排者
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 工作开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 工作结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 需要完成工作的部门列表
        /// </summary>
        public virtual ICollection<DepartmentEntity> Departments { get; set; }
    }
}