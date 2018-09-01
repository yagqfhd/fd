using GanGao.API.Models.OAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GanGao.API.Controllers
{
    /// <summary>
    /// 用户验证相关API
    /// </summary>
    [RoutePrefix("Api/OAuth")]
    public class OAuthController : ApiController
    {
        [Route("CodeToBind"), HttpPost]
        public IHttpActionResult CodeToBind([FromBody] WXCodeToOpenidInput input)
        {
            var code = input.code;
            const string urlFormat = "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code";
            var url = string.Format(urlFormat, "1257420018", "81f130b89f43e0ffcf73c30ea88e2ecc", code);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/heml;charset=UTF-8";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            WebResponse response = request.GetResponse();
            // Display the status.
          Console.WriteLine(((HttpWebResponse)response).StatusDescription);
          // Get the stream containing content returned by the server.
         Stream dataStream = response.GetResponseStream();
             // Open the stream using a StreamReader for easy access.
         StreamReader reader = new StreamReader(dataStream);
           // Read the content.
        string responseFromServer = reader.ReadToEnd();
            dataStream.Close();
            reader.Close();
            return Ok(responseFromServer);
        }
    }
}
