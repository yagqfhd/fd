using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using Microsoft.Owin.Cors;
using System.ComponentModel.Composition;
using Microsoft.Owin.Security.Infrastructure;

[assembly: OwinStartup(typeof(GanGao.API.Startup))]

namespace GanGao.API
{
    public class Startup
    {
        public static HttpConfiguration cfg = null;

        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            cfg = new HttpConfiguration();
            MefConfig.RegisterMef(cfg);
            (cfg.DependencyResolver as MefDependencySolver).Container.ComposeParts(this);
            DatabaseInitializer.Initialize();
            WebApiConfig.Register(cfg);
            //配置Token验证
            ConfiureOAuth(app);
            //这一行代码必须放在ConfiureOAuth(app)之后
            app.UseWebApi(cfg);
            app.UseCors(CorsOptions.AllowAll);
        }

        [Import]
        IOAuthAuthorizationServerProvider tokenProvider=null;
        [Import]
        IAuthenticationTokenProvider refreshToken=null;
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
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
