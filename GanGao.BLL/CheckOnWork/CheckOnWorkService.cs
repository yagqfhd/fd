using GanGao.Interfaces.CheckOnWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FuDong.Common;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using GanGao.Interfaces;
using System.Globalization;
using GanGao.Data.Models.CheckOnWork;
using GanGao.Data.Models;

namespace GanGao.BLL.CheckOnWork
{
    /// <summary>
    /// 教师签到服务层
    /// </summary>
    [Export(typeof(ICheckOnWorkService))]
    public class CheckOnWorkService : ICheckOnWorkService
    {

        #region ///////////属性
        /// <summary>
        /// 自动保存
        /// </summary>
        public bool AutoSaved { get; set; } = true;
        /// <summary>
        /// 软删除，硬删除
        /// </summary>
        public bool isDeleted { get; set; } = true;
        #endregion
        /// <summary>
        /// 签到记录仓储接口
        /// </summary>
        [Import(typeof(IQdRecordRepository<string,QdRecordEntity>))]
        IQdRecordRepository<string, QdRecordEntity> qdRecordStore=null;
        /// <summary>
        /// 工作时间仓储接口
        /// </summary>
        [Import(typeof(IWrokTimeRepository<string,WorkTimeEntity>))]
        IWrokTimeRepository<string, WorkTimeEntity> wrokTimeStore = null;
        /// <summary>
        /// 调休时间仓储接口
        /// </summary>
        [Import(typeof(IAdjustWrokTimeRepository<string,AdjustWorkTimeEntity>))]
        IAdjustWrokTimeRepository<string, AdjustWorkTimeEntity> adjustWrokTimeStore = null;
        /// <summary>
        /// 用户仓储接口
        /// </summary>
        [Import(typeof(IUserRepository<string,UserEntity>))]
        IUserRepository<string, UserEntity> userStore = null;



        public Task<OperationResult> UserCheckOnWorkAsync(string access)
        {
            //获取用户
            var user = userStore.Entities(isDeleted).FirstOrDefault(d => d.Name.Equals(access) || d.Email.Equals(access) || d.WX.Equals(access));
            if (user == null)// 用户不存在
            {
                return Task.FromResult<OperationResult>(new OperationResult(
                    OperationResultType.QueryNull,
                    String.Format(CultureInfo.CurrentCulture, Resources.UserNoExist, access)));
            }
            // 获取当前时间
            var curDateTime = DateTime.Now.ToLocalTime();
            var curDate = curDateTime.Date;
            var curTime = curDateTime.Hour * 60 + curDateTime.Minute;
            // 获取调休时间
            var adjustWrokTime = adjustWrokTimeStore.Entities(isDeleted).Where(d => d.date.Equals(curDate)).ToList();
            if (adjustWrokTime.Count > 0) // 有调休，按照调休进行签到
            {
                #region //////  按照调休进行签到
                bool qdFlag = false;
                string qdMsg = "";
                foreach (var adjust in adjustWrokTime)
                {
                    
                    if (adjust.hasCheckOnWork &&
                        adjust.StartTime > curTime &&
                        (adjust.hasCheckOnWorkEndTimeLast || adjust.EndTime > curTime))
                    {
                        // 签到，签离
                        var qd = new QdRecordEntity
                        {
                            UserId = user.Id,
                            QdType = adjust.QdType,
                            QdTime = curTime,
                            WorkTimeId = adjust.WorkTimeId
                        };
                        qdRecordStore.Insert(qd, AutoSaved);
                        qdMsg += adjust.Name;
                        qdFlag = true;
                    }
                }
                if (qdFlag)
                {
                    qdMsg += user.Name;
                    return Task.FromResult<OperationResult>(new OperationResult(
                    OperationResultType.Success,qdMsg));
                }
                #endregion
            }
            // 获取工作安排
            var curWeek = Convert.ToInt32(curDateTime.DayOfWeek);
            var workTime = wrokTimeStore.Entities(isDeleted).Where(d => d.Week.Equals(curWeek) && d.StartTime<curTime && (d.hasCheckOnWorkEndTimeLast || d.EndTime > curTime)).ToList();
            if(workTime.Count>0) // 有工作安排
            {
                bool qdFlag = false;
                string qdMsg = "";
                foreach (var work in workTime)
                {
                    // 签到，签离
                    var qd = new QdRecordEntity
                    {
                        UserId = user.Id,
                        QdType = work.QdType,
                        QdTime = curTime,
                        WorkTimeId = work.Id
                    };
                    qdRecordStore.Insert(qd, AutoSaved);
                    qdMsg += work.Name;
                    qdFlag = true;
                }
                if (qdFlag)
                {
                    qdMsg += user.Name;
                    return Task.FromResult<OperationResult>(new OperationResult(
                    OperationResultType.Success, qdMsg));
                }
            }
            return Task.FromResult<OperationResult>(new OperationResult(
                    OperationResultType.Success));
        }
    }
}