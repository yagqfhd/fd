using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(GanGao.WX.Startups))]

namespace GanGao.WX
{
    public class Startups
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            //配置Token验证
            ConfiureOAuth(app);
            //这一行代码必须放在ConfiureOAuth(app)之后
            app.UseWebApi(config);
            app.UseCors(CorsOptions.AllowAll);

            
        }

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
                RefreshTokenProvider = new RefreshTokenProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true,
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                Provider = new AuthorizationServerProvider()
            };
            //打开 OAuth服务
            app.UseOAuthAuthorizationServer(serverOptions);
            // 打开 OAuth验证
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
