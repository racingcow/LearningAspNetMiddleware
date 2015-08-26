using System.Threading.Tasks;
using Microsoft.Owin;

namespace MyFunkyMiddleware
{
    public class WhosGotTheFunc : OwinMiddleware
    {
        public const string BEGIN_FUNC = "Who's got the func?";
        public const string END_FUNC = "I've got the func!";

        private readonly OwinMiddleware _next;

        public WhosGotTheFunc(OwinMiddleware next) : base(next)
        {
            _next = next;
        }

        public override async Task Invoke(IOwinContext ctx)
        {
            //await ctx.Response.WriteAsync(BEGIN_FUNC);
            await _next.Invoke(ctx);
            //await ctx.Response.WriteAsync(END_FUNC);
        }
    }
    
}
