using System.Linq;
using System.Web.Http;
using APIIdentityClient;
using Microsoft.Owin;
using Owin;
using Thinktecture.IdentityServer.AccessTokenValidation;

[assembly: OwinStartup(typeof (Startup))]

namespace APIIdentityClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // accept access tokens from identityserver and require a scope of 'api1'
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44302/identity",
                RequiredScopes = new[] {"api1"}
            });

            // configure web api
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            // require authentication for all controllers
            config.Filters.Add(new AuthorizeAttribute());
            
            app.UseWebApi(config);
            
        }
    }
}