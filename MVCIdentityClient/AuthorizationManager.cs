using System.IdentityModel.Claims;
using System.Linq;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace MVCIdentityClient
{
    public class AuthorizationManager : ResourceAuthorizationManager
    {
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            switch (context.Resource.First().Value)
            {
                case "ContactDetails":
                    return AuthorizeContactDetails(context);
                default:
                    return Nok();
            }
        }

        private Task<bool> AuthorizeContactDetails(ResourceAuthorizationContext context)
        {
            switch (context.Action.First().Value)
            {
                case "Read":
                    return Eval(context.Principal.HasClaim(System.Security.Claims.ClaimTypes.Role, "Geek"));
                case "Write":
                    return Eval(context.Principal.HasClaim(System.Security.Claims.ClaimTypes.Role, "Operator"));
                default:
                    return Nok();
            }
        }
    }
}