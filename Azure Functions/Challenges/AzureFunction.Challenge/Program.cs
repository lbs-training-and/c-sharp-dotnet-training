using AzureFunction.Challenge.Function;
using AzureFunction.Challenge.Function.Core.Interfaces;
using AzureFunction.Challenge.Function.Core.Services;
using AzureFunction.Challenge.Function.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddDbContext<AzureFunctionDbContext>((serviceProvider, options) =>
        {
            var hostEnvironment = serviceProvider.GetRequiredService<IHostEnvironment>();
            var projectRoot = Path.GetFullPath(Path.Combine(hostEnvironment.ContentRootPath, "..", "..", ".."));
            var dbPath = Path.Combine(projectRoot, "burgerbytes.db");

            options.UseSqlite($"Data Source={dbPath}", sqliteOptions =>
            {
                sqliteOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                sqliteOptions.MigrationsAssembly(typeof(AzureFunctionDbContext).Assembly.FullName);
            });
        });

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();

        services.AddScoped<DatabaseInitialiser>();

        services.Configure<JsonOptions>(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        });

        services.AddSingleton(serviceProvider =>
        {
            return serviceProvider.GetRequiredService<IOptions<JsonOptions>>().Value.JsonSerializerOptions;
        });
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitialiser>();
    await initializer.InitializeAsync();
}

host.Run();
