using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoardBrowser.Startup))]
namespace BoardBrowser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
