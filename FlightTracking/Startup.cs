using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlightTracking.Startup))]
namespace FlightTracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
