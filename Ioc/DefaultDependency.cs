using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IbgeService.Ioc
{
    public static class DefaultDependency
    {
        public static void AddDefault(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddNewtonsoftJson();
            services
                .AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            if (!string.IsNullOrWhiteSpace(configuration["ApplicationInsights:InstrumentationKey"]))
                services.AddApplicationInsightsTelemetry(configuration);

            services.AddHttpContextAccessor();
            services.AddResponseCaching();
        }
    }
}
