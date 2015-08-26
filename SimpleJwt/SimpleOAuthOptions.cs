using System;
using System.Diagnostics;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace SimpleJwt
{
    public class SimpleOAuthOptions : OAuthAuthorizationServerOptions
    {
        public SimpleOAuthOptions()
        {
            Debug.WriteLine("Constructing SimpleOAuthOptions");
            TokenEndpointPath = new PathString("/Token"); //convention from other MS WebAPI auth methods
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60);
            AccessTokenFormat = new SimpleJwtFormat(new OAuthAuthorizationServerOptions());
            Provider = new SimpleOAuthProvider();
#if DEBUG
            AllowInsecureHttp = true; //only for testing
#endif
        }
    }
}
