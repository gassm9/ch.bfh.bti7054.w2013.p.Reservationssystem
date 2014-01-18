using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reservationsystem.Startup))]
namespace Reservationsystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
