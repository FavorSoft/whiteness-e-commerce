using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(taras_shop.Startup))]
namespace taras_shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
