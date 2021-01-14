using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace IbgeService.Ioc
{
    public static class SwaggerDependency
    {
        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = configuration["SwaggerOptions:DocTitle"],
                    Version = "v1",
                    Description = "Serviço que consome a api do IBGE e informa a frequência dos nomes por década de nascimento",
                    Contact = new OpenApiContact
                    {
                        Name = "IBGE",
                        Url = new Uri("https://servicodados.ibge.gov.br/api/docs/nomes?versao=2")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                opt.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerDependency(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger(options => options
                .RouteTemplate = configuration["SwaggerOptions:JsonRoute"]);

            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "";
                options.DisplayOperationId();
                options.DisplayRequestDuration();
                options.SwaggerEndpoint(
                    configuration["SwaggerOptions:UIEndpoint"],
                    configuration["SwaggerOptions:DocTitle"]);
            });
        }
    }
}
