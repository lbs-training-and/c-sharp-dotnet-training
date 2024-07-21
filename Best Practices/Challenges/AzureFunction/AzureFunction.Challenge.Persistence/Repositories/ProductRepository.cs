using AzureFunction.Challenge.Core.Interfaces;
using AzureFunction.Challenge.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureFunction.Challenge.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AzureFunctionDbContext _context;

        public ProductRepository(AzureFunctionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
