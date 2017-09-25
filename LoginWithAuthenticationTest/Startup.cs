using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginWithAuthenticationTest.Startup))]
namespace LoginWithAuthenticationTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
