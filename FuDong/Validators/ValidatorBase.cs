using FuDong.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FuDong.Validators
{
    /// <summary>
    /// 核心业务数据校验实现基类
    /// </summary>
    public abstract class ValidatorBase<TKey,TEntity,TIRepository> : IEntityValidator<TEntity>
        where TEntity : EntityBase<TKey> , IDefaultEntity<TKey>
        where TIRepository : IRepository<TKey,TEntity>
    {
        /// <summary>
        /// 获取或设置 数据访问仓储对象
        /// </summary>
        [Import]
        protected virtual TIRepository Repository { get; set; }

        /// <summary>
        /// 核心校验方法
        /// </summary>
        public virtual Task<OperationResult> ValidateAsync(TEntity item)
        {
            var entitys = Repository.Entities(true).Where(u =>
                u.Name.Equals(item.Name));
            if (entitys != null)
            {
                return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Failed, 
                    String.Format(CultureInfo.CurrentCulture,
                                Resources.DuplicationName, item.Name)));
            }
            return Task.FromResult<OperationResult>(new OperationResult(OperationResultType.Success));
        }

        /// <summary>
        /// 核心校验方法
        /// </summary>
        public virtual async Task<OperationResult> ValidateAsync(IEnumerable<TEntity> items)
        {
            var result = new OperationResult(OperationResultType.Success);
            foreach (var item in items)
            {
                result = await ValidateAsync(item);
                if (result.ResultType != OperationResultType.Success)
                    return result;
            }
            return result;
        }
    }
}