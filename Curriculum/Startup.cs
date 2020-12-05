using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVGenerator.Startup))]
namespace CVGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
