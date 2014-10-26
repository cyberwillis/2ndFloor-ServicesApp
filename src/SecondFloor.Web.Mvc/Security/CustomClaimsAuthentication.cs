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
    public class CustomClaimsAuthentication : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            if (!incomingPrincipal.Identity.IsAuthenticated)
                return base.Authenticate(resourceName, incomingPrincipal);

            var principal = CreateApplicationPrincipal(incomingPrincipal);

            EstablishSession(principal);

            return principal;
        }

        private ClaimsPrincipal CreateApplicationPrincipal(ClaimsPrincipal incomingPrincipal)
        {
            var userId = incomingPrincipal.FindFirst(ClaimTypes.GroupSid).Value;
            var userName = incomingPrincipal.Identity.Name;

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userId));
            claims.Add(new Claim(ClaimTypes.GroupSid, userId));
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim(ClaimTypes.Email, userName));
            claims.Add(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "MyClaimsProvider"));
            
            //var outcomeIdentity = new ClaimsIdentity(claims); //Not Authenticated user, bacause lacks AuthenticationType

            bool userAdmin = userId == default(Guid).ToString();

            if (userAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                claims.Add(new Claim("resource", "Anunciante"));
                claims.Add(new Claim("action", "Listar"));
                claims.Add(new Claim("action", "List"));
                claims.Add(new Claim("action", "Delete"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "Anunciante"));
            }

            var outcomeIdentity = new ClaimsIdentity(claims, AuthenticationTypes.Password); // Authenticated user, bacause have an AuthenticationType

            var claimPrincipal = new ClaimsPrincipal(outcomeIdentity);

            return claimPrincipal;
        }

        private void EstablishSession(ClaimsPrincipal principal)
        {
            var sessionToken = new SessionSecurityToken(principal, TimeSpan.FromMinutes(12))
            {
                //IsPersistent = false, //make persistent
                //IsReferenceMode = true, //cache on server
            };

            FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(sessionToken);
        }

        public void Logout()
        {
            FederatedAuthentication.SessionAuthenticationModule.DeleteSessionTokenCookie();
            FederatedAuthentication.SessionAuthenticationModule.SignOut();
        }
    }
}