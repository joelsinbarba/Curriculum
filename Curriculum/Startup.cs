using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Curriculum.Startup))]
namespace Curriculum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
