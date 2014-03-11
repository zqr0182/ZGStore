using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZG.Store.Admin.Startup))]
namespace ZG.Store.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
