using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(calcsearchweb.Startup))]
namespace calcsearchweb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
