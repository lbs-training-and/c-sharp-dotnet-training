using AzureFunction.Challenge.Function;
using AzureFunction.Challenge.Function.Core.Interfaces;
using AzureFunction.Challenge.Function.Core.Services;
using AzureFunction.Challenge.Function.Database;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddDbContext<AzureFunctionDbContext>(options =>
            options.UseSqlite("Data Source=burgerbytes.db"));

        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();

        services.AddScoped<DatabaseInitialiser>();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitialiser>();
    await initializer.InitializeAsync();
}

host.Run();
