using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExoticsOwnersRegistry.Startup))]
namespace ExoticsOwnersRegistry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
