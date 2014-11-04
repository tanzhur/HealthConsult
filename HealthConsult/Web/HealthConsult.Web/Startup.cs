using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthConsult.Web.Startup))]
namespace HealthConsult.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
