using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SafetyBoard.Startup))]
namespace SafetyBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
