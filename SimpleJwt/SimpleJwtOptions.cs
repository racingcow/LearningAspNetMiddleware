using System.Diagnostics;
using Microsoft.Owin.Security.Jwt;

namespace SimpleJwt
{
    public class SimpleJwtOptions : JwtBearerAuthenticationOptions
    {
        public SimpleJwtOptions()
        {
            Debug.WriteLine("Constructing SimpleJwtOptions");
            AllowedAudiences = new[] { FedOptions.AUDIENCE };
            IssuerSecurityTokenProviders = new[]
            {
                new SymmetricKeyIssuerSecurityTokenProvider(FedOptions.ISSUER, FedOptions.KeyBytes),
            };
        }
    }
}
