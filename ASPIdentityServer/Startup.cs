using System;
using System.Security.Cryptography.X509Certificates;
using ASPIdentityServer;
using ASPIdentityServer.Repositories;
using Microsoft.Owin;
using Owin;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Models;

[assembly: OwinStartup(typeof (Startup))]

namespace ASPIdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Embedded IdentityServer",
                    SigningCertificate = LoadCertificate(),
                    Factory = InMemoryFactory.Create(
                        Users.Get(),
                        Clients.Get(),
                        Scopes.Get())
                });
            });
        }

        private X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}