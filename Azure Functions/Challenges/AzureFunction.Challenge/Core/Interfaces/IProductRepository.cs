using AzureFunction.Challenge.Function.Core.Entities;

namespace AzureFunction.Challenge.Function.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
