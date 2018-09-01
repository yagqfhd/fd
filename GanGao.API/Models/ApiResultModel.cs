using FuDong.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GanGao.API.Models
{
    /// <summary>
    /// API统一返回模型
    /// </summary>
    public class ApiResultModel<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }    
        /// <summary>
        /// 默认创建
        /// </summary>
        public ApiResultModel()
        {

        }
        /// <summary>
        /// 创建成功返回
        /// </summary>
        /// <param name="data"></param>
        public ApiResultModel(T data)
        {
            StatusCode = HttpStatusCode.OK;
            Data = data;
        }
        /// <summary>
        ///  创建错误返回
        /// </summary>
        /// <param name="msg"></param>
        public ApiResultModel(string msg)
        {            
            StatusCode = HttpStatusCode.BadRequest;
            ErrorMessage = msg;
        }    
    }
}