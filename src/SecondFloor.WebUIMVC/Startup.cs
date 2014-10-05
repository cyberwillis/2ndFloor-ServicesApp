using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecondFloor.WebUIMVC.Startup))]
namespace SecondFloor.WebUIMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
