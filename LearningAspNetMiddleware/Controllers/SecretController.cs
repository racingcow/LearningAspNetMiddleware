using System.Collections.Generic;
using System.Web.Http;

namespace LearningAspNetMiddleware.Controllers
{
    public class SecretController : ApiController
    {
        // GET: api/Secret
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }
    }
}
