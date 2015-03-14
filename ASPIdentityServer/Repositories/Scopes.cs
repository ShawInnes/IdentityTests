using System.Collections.Generic;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Models;

namespace JSIdentityClient.Repositories
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new[]
            {
                ////////////////////////
                // identity scopes
                ////////////////////////

                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Email,
                StandardScopes.Address,
                StandardScopes.OfflineAccess,
                StandardScopes.RolesAlwaysInclude,
                StandardScopes.AllClaims,


                ////////////////////////
                // resource scopes
                ////////////////////////
                new Scope
                {
                    Name = "read",
                    DisplayName = "Read data",
                    Type = ScopeType.Resource,
                    Emphasize = false
                },
                new Scope
                {
                    Name = "write",
                    DisplayName = "Write data",
                    Type = ScopeType.Resource,
                    Emphasize = true
                },
                new Scope
                {
                    Name = "api1",
                    Description = "Web API",
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim(Constants.ClaimTypes.Name),
                        new ScopeClaim(Constants.ClaimTypes.Role)
                    }
                },
                new Scope
                {
                    Enabled = true,
                    Name = "roles",
                    Type = ScopeType.Identity,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim(Constants.ClaimTypes.Name),
                        new ScopeClaim(Constants.ClaimTypes.Role),
                        new ScopeClaim(Constants.ClaimTypes.GivenName),
                        new ScopeClaim(Constants.ClaimTypes.FamilyName),
                        new ScopeClaim(Constants.ClaimTypes.Email)
                    }
                }
            };
        }
    }
}