using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestGat.Startup))]
namespace TestGat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
