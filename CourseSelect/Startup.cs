using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseSelect.Startup))]
namespace CourseSelect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
