using BurgerBooks.Api.Database;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, services) =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddDbContext<BurgerBooksDbContext>(b =>
        {
            var connectionString = context.Configuration.GetConnectionString("BurgerBooksDatabase");
            
            b.UseSqlServer(connectionString, c =>
            {
                c.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });
        });
    })
    .Build();

host.Run();