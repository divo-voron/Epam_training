using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sales.MVCClient.Startup))]
namespace Sales.MVCClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
