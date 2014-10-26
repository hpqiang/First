using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LNDL.Startup))]
namespace LNDL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
