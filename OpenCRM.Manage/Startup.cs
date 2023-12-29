using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenDHS.Shared;

namespace OpenCRM.Manage
{

    public static class StartupModuleExtensions
    {
        public static IServiceCollection AddOpenCRMManage<TDBContext>(this IServiceCollection services) where TDBContext : DataContext
        {
            //TODO: Register all module services here
            return services;
        }
        public static IApplicationBuilder UseOpenCRMManage<TDBContext>(this IApplicationBuilder app) where TDBContext : DataContext
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            using (var scope = app.ApplicationServices.CreateScope())
            {
                //TODO: Use scoped app to use any regitered service before starting up
            }
            return app;
        }
    }
}
