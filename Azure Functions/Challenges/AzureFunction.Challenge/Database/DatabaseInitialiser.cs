using Microsoft.EntityFrameworkCore;

namespace AzureFunction.Challenge.Function.Database
{
    public class DatabaseInitialiser
    {
        private readonly AzureFunctionDbContext _context;

        public DatabaseInitialiser(AzureFunctionDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            // Don't do this in a real-world application. This is just to simplify database creation if you want to start over in the exercises.
            // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli
            await _context.Database.MigrateAsync();
        }
    }
}
