using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(schema_app.Startup))]
namespace schema_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
