using AzureFunction.Challenge.Function.Core.Models.DTOs;

namespace AzureFunction.Challenge.Function.Core.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyCollection<ProductDto>> GetProductsAsync();
    }
}
