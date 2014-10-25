using System.Linq;
using System.Security.Claims;

namespace SecondFloor.Web.Mvc.Security
{
    public class CustomClaimsAuthorization : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            if (!context.Principal.Identity.IsAuthenticated)
                return base.CheckAccess(context);

            var resource = context.Resource.First().Value;
            var action = context.Action.First().Value;

            //Poderia vir de um banco de dados 
            if (resource == "Anunciante" && action == "Listar")
            {
                var result = context.Principal.HasClaim("resource", "Anunciante") && context.Principal.HasClaim("action", "Listar");
                return result;
            }
            if (resource == "Anunciante" && action == "List")
            {
                var result = context.Principal.HasClaim("resource", "Anunciante") && context.Principal.HasClaim("action", "List");
                return result;
            }
            if (resource == "Anunciante" && action == "Delete")
            {
                var result = context.Principal.HasClaim("resource", "Anunciante") && context.Principal.HasClaim("action", "Delete");
                return result;
            }

            return false;
        }
    }
}