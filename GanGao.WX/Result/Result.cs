using System.Net;


namespace GanGao.WX.Result
{
    /// <summary>
    /// API统一返回模型
    /// </summary>
    public class ApiResult<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }

        public static ApiResult<T> Success(HttpStatusCode code , T data)
        {
            return new ApiResult<T>
            {
                StatusCode = code,
                ErrorMessage = "",
                Data = data,
            };
            
        }

        public static ApiResult<T> Success(HttpStatusCode code)
        {
            return new ApiResult<T>
            {
                StatusCode = HttpStatusCode.OK,
                ErrorMessage = "",
                Data = default(T),
            };
        }

        public static ApiResult<T> Success(T data)
        {
            return new ApiResult<T> {
                StatusCode = HttpStatusCode.OK,
                ErrorMessage = "",
                Data = data,
            };            
        }

        public static ApiResult<T> Failed(string msg)
        {
            return new ApiResult<T>
            {
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessage = msg,
                Data = default(T),
            };
        }
        public static ApiResult<T> Failed(HttpStatusCode code,string msg)
        {
            return new ApiResult<T>
            {
                StatusCode = code,
                ErrorMessage = msg,
                Data = default(T),
            };
        }
        public static ApiResult<T> Failed(HttpStatusCode code, string msg,T data)
        {
            return new ApiResult<T>
            {
                StatusCode = code,
                ErrorMessage = msg,
                Data = data,
            };
        }
    }
    
    
}