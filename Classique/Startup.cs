using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Classique.Startup))]
namespace Classique
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
