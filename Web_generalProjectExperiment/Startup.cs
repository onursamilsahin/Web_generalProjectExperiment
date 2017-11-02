using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_generalProjectExperiment.Startup))]
namespace Web_generalProjectExperiment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
