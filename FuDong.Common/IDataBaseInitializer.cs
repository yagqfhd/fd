using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuDong.Common
{
    public enum DBInitType
    {
        DeleteAndReCreate , // 删除重建
        NotExistCreate, // 不存在是创建

    }
    /// <summary>
    /// 数据库初始化操作接口
    /// </summary>
    public interface IDataBaseInitializer
    {
        void Initialize(string dbName,DBInitType initType = DBInitType.NotExistCreate);
    }
}
