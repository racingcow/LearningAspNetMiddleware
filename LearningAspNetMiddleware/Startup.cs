using LearningAspNetMiddleware;
using Microsoft.Owin;
using MyFunkyMiddleware;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace LearningAspNetMiddleware
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseTheFunc();
        }
    }
}
