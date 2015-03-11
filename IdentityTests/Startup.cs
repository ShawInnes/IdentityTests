using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityTests.Startup))]
namespace IdentityTests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
