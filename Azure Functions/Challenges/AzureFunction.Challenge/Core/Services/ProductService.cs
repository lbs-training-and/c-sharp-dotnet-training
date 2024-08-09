using AzureFunction.Challenge.Function.Core.Interfaces;
using AzureFunction.Challenge.Function.Core.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AzureFunction.Challenge.Function.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly AzureFunctionDbContext _context;

        public ProductService(AzureFunctionDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<ProductDto>> GetProductsAsync()
        {
            var result = await _context.Products.ToListAsync();

            var productDtos = result.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            }).ToList();

            return productDtos;
        }
    }
}
