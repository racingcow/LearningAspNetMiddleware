using System;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace SimpleJwt
{
    public class SimpleJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly OAuthAuthorizationServerOptions m_opts;

        public SimpleJwtFormat(OAuthAuthorizationServerOptions opts)
        {
            m_opts = opts;
        }

        public string SignatureAlgorithm => "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";
        public string DigestAlgorithm => "http://www.w3.org/2001/04/xmlenc#sha256";

        public string Protect(AuthenticationTicket ticket)
        {
            if (ticket == null) throw new ArgumentException("ticket");

            var key = new InMemorySymmetricSecurityKey(FedOptions.KeyBytes); //todo: use cert/X509SecurityKey

            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(m_opts.AccessTokenExpireTimeSpan.TotalMinutes);
            var creds = new SigningCredentials(key, SignatureAlgorithm, DigestAlgorithm);
            var token = new JwtSecurityToken(FedOptions.ISSUER, FedOptions.AUDIENCE, ticket.Identity.Claims, now, expires, creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException(); //Not used
        }
    }
}
