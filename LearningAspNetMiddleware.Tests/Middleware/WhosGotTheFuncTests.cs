using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFunkyMiddleware;
using Should.Fluent;

namespace LearningAspNetMiddleware.Tests.Middleware
{
    [TestClass]
    public class WhosGotTheFuncTests
    {
        [TestMethod]
        public void WhosGotTheFuncMiddleware_WhenInvoked_DoesIndeedHaveTheFunc()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var res = server.HttpClient.GetAsync("/").Result;
                var resText = res.Content.ReadAsStringAsync().Result;
                resText.Should().Contain(WhosGotTheFunc.BEGIN_FUNC);
                resText.Should().Contain(WhosGotTheFunc.END_FUNC);
            }
        }
    }
}
