using BurgerBooks.Function.Database;
using BurgerBooks.Function.Database.Entities;
using BurgerBooks.Function.Features.Books.Models;
using BurgerBooks.Function.Features.Genres.Models;
using BurgerBooks.Function.Features.Orders.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BurgerBooks.Function.Features.Orders;

public class OrderFunctions
{
    private readonly ILogger<OrderFunctions> _logger;
    private readonly BurgerBooksDbContext _burgerBooksDbContext;

    public OrderFunctions(ILogger<OrderFunctions> logger, BurgerBooksDbContext burgerBooksDbContext)
    {
        _logger = logger;
        _burgerBooksDbContext = burgerBooksDbContext;
    }
    
    [Function("CreateOrder")]
    public async Task<IActionResult> CreateAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "orders")]
        HttpRequest request,
        [Microsoft.Azure.Functions.Worker.Http.FromBody]
        OrderDto dto)
    {
        var bookIds = dto.OrderBooks.Select(ob => ob.BookId).ToArray();

        var books = await _burgerBooksDbContext.Books
            .Where(b => bookIds.Contains(b.Id))
            .ToArrayAsync();

        if (books.Length != bookIds.Length)
        {
            return new BadRequestResult();
        }

        var orderBooks = dto.OrderBooks.Select(ob => new OrderBook
        {
            Order = null!,
            Book = books.First(b => b.Id == ob.BookId),
            Quantity = ob.Quantity,
            UnitPrice = ob.UnitPrice
        }).ToArray();

        var billingAddress = new BillingAddress
        {
            City = dto.BillingAddress.City,
            Firstname = dto.BillingAddress.Firstname,
            Lastname = dto.BillingAddress.Lastname,
            AddressLine1 = dto.BillingAddress.AddressLine1,
            AddressLine2 = dto.BillingAddress.AddressLine2,
            AddressLine3 = dto.BillingAddress.AddressLine3,
            Postcode = dto.BillingAddress.Postcode
        };
        
        var shippingAddress = dto.ShippingAddress is null ? null : new ShippingAddress
        {
            City = dto.BillingAddress.City,
            Firstname = dto.BillingAddress.Firstname,
            Lastname = dto.BillingAddress.Lastname,
            AddressLine1 = dto.BillingAddress.AddressLine1,
            AddressLine2 = dto.BillingAddress.AddressLine2,
            AddressLine3 = dto.BillingAddress.AddressLine3,
            Postcode = dto.BillingAddress.Postcode,
        };

        var order = new Order
        {
            BillingAddress = billingAddress,
            TotalPrice = dto.TotalPrice,
            ShippingAddress = shippingAddress,
            OrderBooks = orderBooks
        };
        
        await _burgerBooksDbContext.Orders.AddAsync(order);

        await _burgerBooksDbContext.SaveChangesAsync();

        _logger.LogInformation("Order created. Id: {Id}", order.Id);

        dto.Id = order.Id;

        return new OkObjectResult(dto);
    }
}