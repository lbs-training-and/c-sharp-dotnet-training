using AzureFunction.Challenge.Core.Models;

namespace AzureFunction.Challenge.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
