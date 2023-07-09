using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterestingPLACESaroundTheWorld.Startup))]
namespace InterestingPLACESaroundTheWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
