using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineShoppingStore.WebUI.Startup))]
namespace OnlineShoppingStore.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
