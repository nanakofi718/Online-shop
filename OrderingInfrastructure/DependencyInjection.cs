using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Data;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("Database");

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<ApplicationDBContext>((sp, options )=>
            {
                options.AddInterceptors(sp.GetService<ISaveChangesInterceptor>());
                options.UseSqlServer(ConnectionString);
            });
            services.AddScoped<IApplicationDbContext, ApplicationDBContext>();
            return services;
        }
    }
}

