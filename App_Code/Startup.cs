using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Instrum.Startup))]
namespace Instrum
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
