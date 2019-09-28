using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PPPprojekat.Startup))]
namespace PPPprojekat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
