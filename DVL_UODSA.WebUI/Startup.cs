using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DVL_UODSA.WebUI.Startup))]
namespace DVL_UODSA.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
