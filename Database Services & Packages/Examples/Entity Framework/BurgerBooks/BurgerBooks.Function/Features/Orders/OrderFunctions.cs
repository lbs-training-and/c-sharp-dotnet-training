using BurgerBooks.Function.Database;
using BurgerBooks.Function.Database.Entities;
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

        var shippingAddress = dto.ShippingAddress is null
            ? null
            : new ShippingAddress
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
            TotalPrice = dto.OrderBooks.Sum(ob => ob.UnitPrice * ob.Quantity),
            ShippingAddress = shippingAddress,
            OrderBooks = orderBooks
        };

        await _burgerBooksDbContext.Orders.AddAsync(order);

        await _burgerBooksDbContext.SaveChangesAsync();

        _logger.LogInformation("Order created. Id: {Id}", order.Id);

        return new OkObjectResult(new IdDto(order.Id));
    }

    [Function("GetOrders")]
    public async Task<IActionResult> GetAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "orders")]
        HttpRequest request,
        string? shippingAddressPostcode,
        int page = 1,
        int pageSize = 10)
    {
        var orders = await _burgerBooksDbContext.Orders
            .AsNoTracking()
            .Include(o => o.BillingAddress)
            .Include(o => o.OrderBooks).ThenInclude(ob => ob.Book)
            .Where(o => shippingAddressPostcode == null || (o.ShippingAddress != null && o.ShippingAddress.Postcode == shippingAddressPostcode))
            .OrderBy(o => o.Id)
            .Skip(page * pageSize - pageSize)
            .Take(pageSize)
            .ToArrayAsync();

        var dtos = orders.Select(o => new OrderDto
            {
                Id = o.Id,
                TotalPrice = o.TotalPrice,
                BillingAddress = new AddressDto
                {
                    City = o.BillingAddress.City,
                    Firstname = o.BillingAddress.Firstname,
                    Lastname = o.BillingAddress.Lastname,
                    AddressLine1 = o.BillingAddress.AddressLine1,
                    AddressLine2 = o.BillingAddress.AddressLine2,
                    AddressLine3 = o.BillingAddress.AddressLine3,
                    Postcode = o.BillingAddress.Postcode,
                },
                ShippingAddress = o.ShippingAddress is null
                    ? null
                    : new AddressDto
                    {
                        City = o.BillingAddress.City,
                        Firstname = o.BillingAddress.Firstname,
                        Lastname = o.BillingAddress.Lastname,
                        AddressLine1 = o.BillingAddress.AddressLine1,
                        AddressLine2 = o.BillingAddress.AddressLine2,
                        AddressLine3 = o.BillingAddress.AddressLine3,
                        Postcode = o.BillingAddress.Postcode,
                    },
                OrderBooks = o.OrderBooks.Select(ob => new OrderBookDto
                {
                    UnitPrice = ob.UnitPrice,
                    Quantity = ob.Quantity,
                    Id = ob.Id,
                    BookId = ob.Book.Id
                }).ToArray()
            })
            .ToArray();

        return new OkObjectResult(dtos);
    }

    [Function("GetOrder")]
    public async Task<IActionResult> GetSingleAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "orders/{id}")]
        HttpRequest request,
        int id)
    {
        var order = await _burgerBooksDbContext.Orders
            .AsNoTracking()
            .Include(o => o.ShippingAddress)
            .Include(o => o.BillingAddress)
            .Include(o => o.OrderBooks).ThenInclude(ob => ob.Book)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            return new NotFoundResult();
        }

        var dto = new OrderDto
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice,
            BillingAddress = new AddressDto
            {
                City = order.BillingAddress.City,
                Firstname = order.BillingAddress.Firstname,
                Lastname = order.BillingAddress.Lastname,
                AddressLine1 = order.BillingAddress.AddressLine1,
                AddressLine2 = order.BillingAddress.AddressLine2,
                AddressLine3 = order.BillingAddress.AddressLine3,
                Postcode = order.BillingAddress.Postcode,
            },
            ShippingAddress = order.ShippingAddress is null
                ? null
                : new AddressDto
                {
                    City = order.BillingAddress.City,
                    Firstname = order.BillingAddress.Firstname,
                    Lastname = order.BillingAddress.Lastname,
                    AddressLine1 = order.BillingAddress.AddressLine1,
                    AddressLine2 = order.BillingAddress.AddressLine2,
                    AddressLine3 = order.BillingAddress.AddressLine3,
                    Postcode = order.BillingAddress.Postcode,
                },
            OrderBooks = order.OrderBooks.Select(ob => new OrderBookDto
            {
                UnitPrice = ob.UnitPrice,
                Quantity = ob.Quantity,
                Id = ob.Id,
                BookId = ob.Book.Id
            }).ToArray()
        };

        return new OkObjectResult(dto);
    }

    [Function("UpdateOrder")]
    public async Task<IActionResult> UpdateAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "orders/{id}")]
        HttpRequest request,
        [Microsoft.Azure.Functions.Worker.Http.FromBody]
        OrderDto dto,
        int id)
    {
        var order = await _burgerBooksDbContext.Orders
            .Include(o => o.ShippingAddress)
            .Include(o => o.BillingAddress)
            .Include(o => o.OrderBooks).ThenInclude(ob => ob.Book)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            return new NotFoundResult();
        }
        
        var bookIds = dto.OrderBooks.Select(ob => ob.BookId).ToArray();

        var books = await _burgerBooksDbContext.Books
            .Where(b => bookIds.Contains(b.Id))
            .ToArrayAsync();

        if (books.Length != bookIds.Length)
        {
            return new BadRequestResult();
        }

        var orderBooks = order.OrderBooks.ToArray();
        order.OrderBooks.Clear();

        foreach (var obDto in dto.OrderBooks)
        {
            var orderBook = orderBooks.FirstOrDefault(ob => ob.Id == obDto.Id) ?? new OrderBook
            {
                Order = null!,
                Book = null!
            };

            orderBook.UnitPrice = obDto.UnitPrice;
            orderBook.Quantity = obDto.Quantity;
            orderBook.Book = books.First(b => b.Id == obDto.BookId);
            
            order.OrderBooks.Add(orderBook);
        }

        order.TotalPrice = dto.OrderBooks.Sum(ob => ob.UnitPrice * ob.Quantity);

        order.BillingAddress = new BillingAddress
        {
            City = dto.BillingAddress.City,
            Firstname = dto.BillingAddress.Firstname,
            Lastname = dto.BillingAddress.Lastname,
            AddressLine1 = dto.BillingAddress.AddressLine1,
            AddressLine2 = dto.BillingAddress.AddressLine2,
            AddressLine3 = dto.BillingAddress.AddressLine3,
            Postcode = dto.BillingAddress.Postcode
        };

        order.ShippingAddress = dto.ShippingAddress is null
            ? null
            : new ShippingAddress
            {
                City = dto.BillingAddress.City,
                Firstname = dto.BillingAddress.Firstname,
                Lastname = dto.BillingAddress.Lastname,
                AddressLine1 = dto.BillingAddress.AddressLine1,
                AddressLine2 = dto.BillingAddress.AddressLine2,
                AddressLine3 = dto.BillingAddress.AddressLine3,
                Postcode = dto.BillingAddress.Postcode,
            };

        await _burgerBooksDbContext.SaveChangesAsync();

        _logger.LogInformation("Order updated. Id: {Id}", order.Id);

        return new OkResult();
    }
    
    [Function("DeleteOrder")]
    public async Task<IActionResult> DeleteAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "orders/{id}")]
        HttpRequest request,
        int id)
    {
        var order = await _burgerBooksDbContext.Orders.FindAsync(id);

        if (order == null)
        {
            return new NotFoundResult();
        }
        
        _burgerBooksDbContext.Orders.Remove(order);

        await _burgerBooksDbContext.SaveChangesAsync();
        
        _logger.LogInformation("Order deleted. Id: {Id}", id);

        return new OkResult();
    }
}