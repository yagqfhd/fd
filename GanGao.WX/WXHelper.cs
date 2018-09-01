using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace GanGao.WX
{
    public static class WXHelper
    {
        const string WX_Code_OpenID_URL = "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code";
        const string WX_APPID = "wxcc8bc05d89eaa8a5";
        const string WX_APPSECRET = "df37fd5a80be9ddcf5a92b7c5510298f";
        //获得Token
        public static string Get_token(string Code)
        {
            Console.WriteLine("URL:{0}", string.Format(WX_Code_OpenID_URL, WX_APPID, WX_APPSECRET, Code));
            string Str = GetJson(string.Format(WX_Code_OpenID_URL, WX_APPID,WX_APPSECRET, Code));
            return Str;
        }

        //下载数据
        public static string GetJson(string url)
        {
            string res = "";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                res = reader.ReadToEnd();
            }

            return res;
        }
    }
}