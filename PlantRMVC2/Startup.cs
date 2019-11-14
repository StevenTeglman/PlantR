using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlantRMVC2.Startup))]
namespace PlantRMVC2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
