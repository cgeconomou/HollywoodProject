using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalApp.Startup))]
namespace FinalApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
