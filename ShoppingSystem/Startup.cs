using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingSystem.Startup))]
namespace ShoppingSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
