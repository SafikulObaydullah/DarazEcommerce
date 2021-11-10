using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DarazEcommerce.Startup))]
namespace DarazEcommerce
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
