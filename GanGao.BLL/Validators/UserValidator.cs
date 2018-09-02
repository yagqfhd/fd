using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using FuDong.Common;
using GanGao.Data.Models;
using FuDong.Validators;
using GanGao.Interfaces;

namespace GanGao.BLL.Validators
{
    /// <summary>
    ///     校验实现——用户信息名称重名检查
    /// </summary>
    [Export(typeof(IEntityValidator<UserEntity>))]
    public class UserValidator : ValidatorBase<string, UserEntity,IUserRepository<string, UserEntity>>, IEntityValidator<UserEntity>
    {
        /// <summary>
        /// 校验方法重写
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override async Task<OperationResult> ValidateAsync(UserEntity item)
        {
            //检查用户名和Email , 昵称，姓名
            var users = Repository.Entities(true).Where(u=>
                u.Email.Equals(item.Email) ||
                u.PhoneNumber.Equals(item.PhoneNumber) ||
                u.IdCard.Equals(item.IdCard)||
                u.WX.Equals(item.WX));
            if (users != null)
            {
                Console.WriteLine("UserValidator:Users={0}", users.Count());
                foreach (var user in users)
                {
                    var err = "";
                    if (!EqualityComparer<string>.Default.Equals(user.Id, item.Id))
                    {                        
                        if (user.Email.Equals(item.Email))
                            err += String.Format(CultureInfo.CurrentCulture,
                                Resources.DuplicationName, item.Email);
                        if (user.PhoneNumber.Equals(item.PhoneNumber))
                            err += String.Format(CultureInfo.CurrentCulture,
                                Resources.DuplicationName, item.PhoneNumber);
                        if (user.PhoneNumber.Equals(item.PhoneNumber))
                            err += String.Format(CultureInfo.CurrentCulture,
                                Resources.DuplicationName, item.PhoneNumber);
                        if (user.PhoneNumber.Equals(item.PhoneNumber))
                            err += String.Format(CultureInfo.CurrentCulture,
                                Resources.DuplicationName, item.PhoneNumber);
                        return new OperationResult(OperationResultType.Failed, err);                                
                    }
                }

            }
            return await base.ValidateAsync(item);
        }
    }
}