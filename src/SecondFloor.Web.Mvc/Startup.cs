using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecondFloor.Web.Mvc.Startup))]
namespace SecondFloor.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
