using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DbmsSims.Startup))]
namespace DbmsSims
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
