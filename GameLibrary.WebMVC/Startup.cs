using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameLibrary.WebMVC.Startup))]
namespace GameLibrary.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
