using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ActionResults.Startup))]
namespace ActionResults
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
