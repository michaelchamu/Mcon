using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EM_ConProjects.Startup))]
namespace EM_ConProjects
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
