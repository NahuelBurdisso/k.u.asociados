using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kuasociados.Startup))]
namespace kuasociados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
