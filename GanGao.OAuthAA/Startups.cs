using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Infrastructure;
using System.ComponentModel.Composition;
using Newtonsoft.Json.Serialization;

[assembly: OwinStartup(typeof(GanGao.OAuth.Startups))]

namespace GanGao.OAuth
{
    public class Startups
    {
        public static HttpConfiguration cfg = null;

        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            cfg = new HttpConfiguration();
            MefConfig.RegisterMef(cfg);
            (cfg.DependencyResolver as MefDependencySolver).Container.ComposeParts(this);
            //DatabaseInitializer.Initialize();
            WebApiConfig.Register(cfg);
            //配置Token验证
            ConfiureOAuth(app);
            //这一行代码必须放在ConfiureOAuth(app)之后
            app.UseWebApi(cfg);
            //app.UseCors(CorsOptions.AllowAll);
        }

        [Import]
        IOAuthAuthorizationServerProvider tokenProvider = null;
        [Import]
        IAuthenticationTokenProvider refreshToken = null;
        /// <summary>
        /// OAuth验证服务配置
        /// </summary>
        /// <param name="app"></param>
        public void ConfiureOAuth(IAppBuilder app)
        {

            // OAuth 验证服务器配置信息
            var serverOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                RefreshTokenProvider = refreshToken, // new RefreshTokenProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true,
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                Provider = tokenProvider//new AuthorizationServerProvider()
            };
            //打开 OAuth服务
            app.UseOAuthAuthorizationServer(serverOptions);
            // 打开 OAuth验证
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }


    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            Console.WriteLine("GanGao.OAuth.WebAPIConfig.Register");
            //跨域配置
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //// 干掉XML序列化器
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            //修改App_Start文件夹中的WebApiConfig.cs文件，实现api数据通过json格式返回
            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //jsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            ////jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            ////config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            // 对 JSON 数据使用混合大小写。跟属性名同样的大小.输出
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver();

            // 对Null 返回空字符串
            //config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
