using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kalyani1.Startup))]
namespace Kalyani1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
