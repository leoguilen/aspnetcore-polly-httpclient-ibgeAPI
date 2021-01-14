using IbgeService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace IbgeService.Ioc
{
    public static class ServicesDependency
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Error policies
            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                 .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(15);

            services.AddHttpClient<IIbgeService, Services.IbgeService>("IBGE", client =>
            {
                client.BaseAddress = new Uri(configuration["ApiConfig:BaseUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.Timeout = TimeSpan.FromSeconds(60);
            })
            .AddPolicyHandler(retryPolicy)
            .AddPolicyHandler(timeoutPolicy);
        }
    }
}
