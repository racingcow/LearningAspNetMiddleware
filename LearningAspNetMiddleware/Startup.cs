using LearningAspNetMiddleware;
using Microsoft.Owin;
using MyFunkyMiddleware;
using Owin;
using SimpleJwt;

[assembly: OwinStartup(typeof(Startup))]

namespace LearningAspNetMiddleware
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseTheFunc();
            app.UseOAuthAuthorizationServer(new SimpleOAuthOptions()); //Issues tokens
            app.UseJwtBearerAuthentication(new SimpleJwtOptions()); //Validates tokens
        }
    }
}
