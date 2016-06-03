using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GerenciadorConsultasMedicas.Startup))]
namespace GerenciadorConsultasMedicas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
