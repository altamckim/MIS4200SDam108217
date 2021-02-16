using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(am108217MIS4200.Startup))]
namespace am108217MIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
