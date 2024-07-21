namespace AzureFunction.Challenge.Persistence
{
    public class DatabaseInitialiser
    {
        private readonly AzureFunctionDbContext _context;

        public DatabaseInitialiser(AzureFunctionDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();
        }
    }
}
