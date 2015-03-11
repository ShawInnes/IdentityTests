using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace ASPIdentityServer.Repositories
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                // no human is involved
                new Client
                {
                    ClientName = "Silicon-only Client",
                    ClientId = "silicon",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,
                    Flow = Flows.ClientCredentials,
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    }
                },
                // human is involved
                new Client
                {
                    ClientName = "Silicon on behalf of Carbon Client",
                    ClientId = "carbon",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,
                    Flow = Flows.ResourceOwner,
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret("21B5F798-BE55-42BC-8AA8-0025B903DC3B".Sha256())
                    }
                },
                new Client
                {
                    Enabled = true,
                    ClientName = "MVC Client",
                    ClientId = "mvc",
                    Flow = Flows.Implicit,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44303/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44303/"
                    }
                }
            };
        }
    }
}