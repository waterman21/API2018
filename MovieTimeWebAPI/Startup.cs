using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieTimeWebAPI.Startup))]
namespace MovieTimeWebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
