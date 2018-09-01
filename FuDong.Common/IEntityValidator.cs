using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuDong.Common
{
    /// <summary>
    /// 校验接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntityValidator<TEntity>//, TIRepository>
    {

        //TIRepository Repository { get; set; }

        /// <summary>
        /// 校验核心
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<OperationResult> ValidateAsync(TEntity item);

        /// <summary>
        /// 校验核心
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<OperationResult> ValidateAsync(IEnumerable<TEntity> items);
    }
}
