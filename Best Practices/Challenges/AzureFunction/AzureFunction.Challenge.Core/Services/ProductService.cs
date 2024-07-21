using AzureFunction.Challenge.Core.Interfaces;
using AzureFunction.Challenge.Core.Models.DTOs;

namespace AzureFunction.Challenge.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var result = await _productRepository.GetProductsAsync();

            var productDtos = result.Select(product => new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            });

            return productDtos;
        }
    }
}
