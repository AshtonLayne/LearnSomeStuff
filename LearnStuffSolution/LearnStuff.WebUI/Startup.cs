using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearnStuff.WebUI.Startup))]
namespace LearnStuff.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
