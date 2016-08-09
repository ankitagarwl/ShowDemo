using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(html.Startup))]
namespace html
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
