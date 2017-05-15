using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankProjectWeb.Startup))]
namespace BankProjectWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
