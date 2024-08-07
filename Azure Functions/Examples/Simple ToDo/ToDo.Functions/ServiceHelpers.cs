using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ToDo.Functions.Services;

namespace ToDo.Functions;

public static class ServiceHelpers
{
    public static IHostBuilder ConfigureToDoServices(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices(services =>
        {
            services.AddApplicationInsightsTelemetryWorkerService();
            services.ConfigureFunctionsApplicationInsights();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
            {
                var opts = new OpenApiConfigurationOptions
                {
                    Info = new OpenApiInfo
                    {
                        Version = "1.0.0",
                        Title = "ToDo API",
                        Description = "A simple ToDo API"
                    },
                    OpenApiVersion = OpenApiVersionType.V3
                };
                return opts;
            });
        });
    }
}