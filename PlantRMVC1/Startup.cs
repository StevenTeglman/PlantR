using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlantRMVC1.Startup))]
namespace PlantRMVC1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
