using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Posiciones.Startup))]
namespace Posiciones
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
