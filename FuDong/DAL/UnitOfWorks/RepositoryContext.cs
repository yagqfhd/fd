using FuDong.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FuDong.DAL.UnitOfWorks
{
    /// <summary>
    ///     数据单元操作类
    /// </summary>
    [Export(typeof(IUnitOfWork))]
    internal class RepositoryContext : UnitOfWorkContextBase
    {
        public RepositoryContext() { }
        /// <summary>
        ///     获取 当前使用的数据访问上下文对象
        /// </summary>
        protected override DbContext Context
        {
            get { return EFDbContext; }
        }

        [Import(typeof(DbContext))]
        private EFDbContext EFDbContext { get; set; }
    }
}