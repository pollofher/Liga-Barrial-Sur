using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLigaSur.Startup))]
namespace MVCLigaSur
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
