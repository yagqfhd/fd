using System.Globalization;

namespace FuDong.DAL.UnitOfWorks
{
    /// <summary>
    ///     SQL数据辅助操作类
    /// </summary>
    internal class SQLErrorMessage
    {
        /// <summary>
        ///     由错误码返回指定的自定义SqlException异常信息
        /// </summary>
        /// <param name="number"> </param>
        /// <returns> </returns>
        public static string SqlMessage(int number)
        {
            string msg = string.Empty;
            switch (number)
            {
                case 2:
                    msg = string.Format(CultureInfo.CurrentCulture, Resources.ConnTimeOut); // "连接数据库超时，请检查网络连接或者数据库服务器是否正常。";
                    break;
                case 17:
                    msg = string.Format(CultureInfo.CurrentCulture, Resources.ServerNotExist); //  "SqlServer服务不存在或拒绝访问。";
                    break;
                case 17142:
                    msg = string.Format(CultureInfo.CurrentCulture, Resources.ServerStop); //  "SqlServer服务已暂停，不能提供数据服务。";
                    break;
                case 2812:
                    msg = string.Format(CultureInfo.CurrentCulture, Resources.StoreNotExist); //  "指定存储过程不存在。";
                    break;
                case 208:
                    msg = string.Format(CultureInfo.CurrentCulture, Resources.TableNotExist); //"指定名称的表不存在。";
                    break;
                case 4060: //数据库无效。
                    msg = string.Format(CultureInfo.CurrentCulture, Resources.DataBaseInvalid);//"所连接的数据库无效。";
                    break;
                case 18456: //登录失败
                    msg = string.Format(CultureInfo.CurrentCulture, Resources.DataBaseUserPasswordError);//"使用设定的用户名与密码登录数据库失败。";
                    break;
                case 547:
                    msg = string.Format(CultureInfo.CurrentCulture, Resources.ForeignKeyNoSaveData);//"外键约束，无法保存数据的变更。";
                    break;
                case 2627:
                    msg = string.Format(CultureInfo.CurrentCulture, Resources.KeyNoInsert); // "主键重复，无法插入数据。";
                    break;
                case 2601:
                    msg = string.Format(CultureInfo.CurrentCulture, Resources.Unknown);//"未知错误。";
                    break;
            }
            return msg;
        }
    }
}