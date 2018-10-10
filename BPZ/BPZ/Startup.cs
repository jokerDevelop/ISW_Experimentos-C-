using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BPZ.Startup))]
namespace BPZ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
