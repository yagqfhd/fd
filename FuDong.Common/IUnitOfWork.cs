﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuDong.Common
{
    /// <summary>
    ///     业务单元操作接口
    /// </summary>
    public interface IUnitOfWork
    {
        #region 属性

        /// <summary>
        ///     获取 当前单元操作是否已被提交
        /// </summary>
        bool IsCommitted { get; }

        #endregion

        #region 方法

        /// <summary>
        ///     提交当前单元操作的结果
        /// </summary>
        /// <returns></returns>
        int Commit(bool isSave = false);

        /// <summary>
        ///     把当前单元操作回滚成未提交状态
        /// </summary>
        void Rollback();

        #endregion
    }
}
