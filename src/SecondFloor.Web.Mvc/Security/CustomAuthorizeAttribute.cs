using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using AuthorizationContext = System.Security.Claims.AuthorizationContext;

namespace SecondFloor.Web.Mvc.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _resource;
        private readonly string _action;

        public CustomAuthorizeAttribute(string resource, string action)
        {
            _resource = resource;
            _action = action;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var principal = httpContext.User;

            var authorization = new CustomClaimsAuthorization();

            if (principal.Identity.IsAuthenticated)
            {
                var authContext = new AuthorizationContext(ClaimsPrincipal.Current, _resource, _action);

                return authorization.CheckAccess(authContext);
            }

            return base.AuthorizeCore(httpContext);
        }
    }
}