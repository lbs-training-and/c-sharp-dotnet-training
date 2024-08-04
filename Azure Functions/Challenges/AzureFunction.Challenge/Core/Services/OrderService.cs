using AzureFunction.Challenge.Function.Core.Entities;
using AzureFunction.Challenge.Function.Core.Interfaces;
using AzureFunction.Challenge.Function.Core.Models;
using AzureFunction.Challenge.Function.Core.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AzureFunction.Challenge.Function.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly AzureFunctionDbContext _context;
        public OrderService(AzureFunctionDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrder(OrderDto orderDto)
        {
            var productIds = orderDto.OrderProducts.Select(op => op.Product.Id).ToList();

            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

            var productDictionary = products.ToDictionary(p => p.Id);

            var order = new Order
            {
                DeliveryAddress = new Address
                {
                    Name = orderDto.DeliveryAddress.Name,
                    AddressLineOne = orderDto.DeliveryAddress.AddressLineOne,
                    AddressLineTwo = orderDto.DeliveryAddress.AddressLineTwo,
                    City = orderDto.DeliveryAddress.City,
                    PostalCode = orderDto.DeliveryAddress.PostalCode,
                    Country = orderDto.DeliveryAddress.Country
                },
                BillingAddress = new Address
                {
                    Name = orderDto.BillingAddress.Name,
                    AddressLineOne = orderDto.BillingAddress.AddressLineOne,
                    AddressLineTwo = orderDto.DeliveryAddress.AddressLineTwo,
                    City = orderDto.BillingAddress.City,
                    PostalCode = orderDto.BillingAddress.PostalCode,
                    Country = orderDto.BillingAddress.Country
                },
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

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var result = await _context.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.Id == id) ?? new Order();

            var orderDto = new OrderDto
            {
                DeliveryAddress = result.DeliveryAddress,
                BillingAddress = result.BillingAddress,
                Email = result.Email,
                Phone = result.Phone,
                OrderProducts = result.OrderProducts.Select(orderProduct => new OrderProductDto
                {
                    Quantity = orderProduct.Quantity,
                    Product = new ProductDto
                    {
                        Name = orderProduct.Product.Name,
                        Description = orderProduct.Product.Description,
                        Price = orderProduct.Product.Price
                    },
                    Notes = orderProduct.Notes
                }).ToList()
            };


            return orderDto;
        }
    }
}
