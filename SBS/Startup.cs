using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SBS.Startup))]
namespace SBS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
