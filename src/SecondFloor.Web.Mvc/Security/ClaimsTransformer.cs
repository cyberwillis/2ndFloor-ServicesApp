using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Security;

namespace SecondFloor.Web.Mvc.Security
{
    public class ClaimsTransformer : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            if (!incomingPrincipal.Identity.IsAuthenticated)
                return base.Authenticate(resourceName, incomingPrincipal);

            var principal = CreateApplicationPrincipal(incomingPrincipal);

            EstablishSession(principal);

            return principal;
        }

        private void EstablishSession(ClaimsPrincipal principal)
        {
            var sessionToken = new SessionSecurityToken(principal, TimeSpan.FromMinutes(10));

            FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(sessionToken);
        }

        private ClaimsPrincipal CreateApplicationPrincipal(ClaimsPrincipal incomingPrincipal)
        {
            var userName = incomingPrincipal.Identity.Name;
            var userId = incomingPrincipal.FindFirst(ClaimTypes.Role).Value;

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userId));
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "MyClaimsProvider"));
            claims.Add(new Claim(ClaimTypes.Email, userName));
            
            var outcomePrincipal = new ClaimsIdentity(claims); //Not Authenticated user, bacause lacks AuthenticationType

            bool userAdmin = userId == default(Guid).ToString();
            
            if (userAdmin)
                outcomePrincipal.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            else
                outcomePrincipal.AddClaim(new Claim(ClaimTypes.Role, "Anunciante"));
            
            outcomePrincipal = new ClaimsIdentity(claims, AuthenticationTypes.Password); // Authenticated user, bacause have an AuthenticationType

            var claimPrincipal = new ClaimsPrincipal(outcomePrincipal);

            return claimPrincipal;
        }

        public void Logout()
        {
            FederatedAuthentication.SessionAuthenticationModule.DeleteSessionTokenCookie();
        }
    }
}