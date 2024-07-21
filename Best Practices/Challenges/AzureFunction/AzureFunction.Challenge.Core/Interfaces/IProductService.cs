using AzureFunction.Challenge.Core.Models.DTOs;

namespace AzureFunction.Challenge.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
    }
}
