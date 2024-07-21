using AzureFunction.Challenge.Core.Interfaces;
using AzureFunction.Challenge.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureFunction.Challenge.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AzureFunctionDbContext _context;

        public OrderRepository(AzureFunctionDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByIdAsync(int Id)
        {
            return await _context.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.Id == Id) ?? new Order();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<int> SaveOrderAsync(OrderDto orderDto)
        {
            var productIds = orderDto.OrderProducts.Select(op => op.Product.Id).ToList();

            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

            var productDictionary = products.ToDictionary(p => p.Id);

            var order = new Order
            {
                DeliveryAddress = orderDto.DeliveryAddress,
                BillingAddress = orderDto.BillingAddress,
                Email = orderDto.Email,
                Phone = orderDto.Phone,
                OrderProducts = orderDto.OrderProducts.Select(op => new OrderProduct
                {
                    Quantity = op.Quantity,
                    ProductId = productDictionary[op.Product.Id].Id,
                    Price = productDictionary[op.Product.Id].Price,
                    Product = productDictionary[op.Product.Id],
                    Notes = op.Notes
                }).ToList()
            };

            var entityEntry = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return entityEntry.Entity.Id;
        }
    }
}
