using AzureFunction.Challenge.Core.Interfaces;
using AzureFunction.Challenge.Core.Services;
using AzureFunction.Challenge.Persistence;
using AzureFunction.Challenge.Persistence.Repositories;
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

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.AddScoped<DatabaseInitialiser>();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitialiser>();
    initializer.Initialize();
}

host.Run();
