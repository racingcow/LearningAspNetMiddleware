using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace SimpleJwt
{
    public class SimpleOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext ctx)
        {
            //verify credentials against identity store
            //add data to context
            try
            {
                var username = ctx.Parameters["username"];
                var password = ctx.Parameters["password"];

                if (username == "racingcow" && password == "password") //todo: check db here
                {
                    ctx.OwinContext.Set("racingcow:username", username);
                    ctx.Validated();
                }
                else
                {
                    ctx.SetError("Invalid credentials");
                    ctx.Rejected();
                }
            }
            catch (Exception)
            {
                ctx.SetError("Server error");
                ctx.Rejected();
                throw;
            }

            return Task.FromResult(0);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext ctx)
        {
            //grab data that was placed into context by ValidateClientAuthentication
            //use data to add claims for auth ticket/jwt
            var ident = new ClaimsIdentity("racingcow");
            var username = ctx.OwinContext.Get<string>("racingcow:username");
            ident.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));
            ident.AddClaim(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "minion"));
            ctx.Validated(ident);
            return Task.FromResult(0);
        }
    }
}
