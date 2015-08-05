using Owin;

namespace MyFunkyMiddleware
{
    public static class Extensions
    {
        public static IAppBuilder UseTheFunc(this IAppBuilder app)
        {
            return app.Use<WhosGotTheFunc>();
        }
    }
}
