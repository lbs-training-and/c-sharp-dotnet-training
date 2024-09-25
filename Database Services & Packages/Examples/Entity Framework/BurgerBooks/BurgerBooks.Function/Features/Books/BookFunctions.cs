using BurgerBooks.Function.Database;
using BurgerBooks.Function.Database.Entities;
using BurgerBooks.Function.Features.Books.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BurgerBooks.Function.Features.Books;

public class BookFunctions
{
    private readonly ILogger _logger;
    private readonly BurgerBooksDbContext _burgerBooksDbContext;
    
    public BookFunctions(ILogger<BookFunctions> logger, BurgerBooksDbContext burgerBooksDbContext)
    {
        _logger = logger;
        _burgerBooksDbContext = burgerBooksDbContext;
    }

    [Function("CreateBook")]
    public async Task<IActionResult> CreateAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "books")]
        HttpRequest request,
        [Microsoft.Azure.Functions.Worker.Http.FromBody]
        BookDto dto)
    {
        var genre = await _burgerBooksDbContext.Genres.FindAsync(dto.GenreId);

        if (genre == null)
        {
            return new BadRequestResult();
        }

        var authors = await _burgerBooksDbContext.Authors
            .Where(a => dto.AuthorIds.Contains(a.Id))
            .ToArrayAsync();

        if (authors.Length == 0)
        {
            return new BadRequestResult();
        }

        var book = new Book
        {
            Authors = authors,
            Genre = genre,
            Name = dto.Name,
            Published = dto.Published,
            Price = dto.Price,
            BookOrders = new List<OrderBook>()
        };
        
        await _burgerBooksDbContext.Books.AddAsync(book);

        await _burgerBooksDbContext.SaveChangesAsync();

        _logger.LogInformation("Book created. Id: {Id}", genre.Id);

        return new OkObjectResult(new IdDto(book.Id));
    }
    
    [Function("GetBooks")]
    public async Task<IActionResult> GetAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "books")]
        HttpRequest request,
        int? authorId,
        int? genreId,
        int page = 1,
        int pageSize = 10)
    {
        var books = await _burgerBooksDbContext.Books
            .AsNoTracking()
            .Include(b => b.Authors)
            .Include(b => b.Genre)
            .Where(b => authorId == null || b.Authors.Any(a => a.Id == authorId))
            .Where(b => genreId == null || b.Genre.Id == genreId)
            .OrderBy(b => b.Id)
            .Skip(page * pageSize - pageSize)
            .Take(pageSize)
            .Select(b => new BookDto
            {
                Name = b.Name,
                Published = b.Published,
                Price = b.Price,
                Id = b.Id,
                AuthorIds = b.Authors.Select(a => a.Id).ToArray(),
                GenreId = b.Genre.Id
            })
            .ToArrayAsync();
        
        return new OkObjectResult(books);
    }
    
    [Function("GetBook")]
    public async Task<IActionResult> GetSingleAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "books/{id}")]
        HttpRequest request,
        int id)
    {
        var book = await _burgerBooksDbContext.Books
            .AsNoTracking()
            .Include(b => b.Authors)
            .Include(b => b.Genre)
            .Select(b => new BookDto
            {
                Name = b.Name,
                Published = b.Published,
                Price = b.Price,
                Id = b.Id,
                AuthorIds = b.Authors.Select(a => a.Id).ToArray(),
                GenreId = b.Genre.Id
            })
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            return new NotFoundResult();
        }
        
        return new OkObjectResult(book);
    }
    
    [Function("UpdateBook")]
    public async Task<IActionResult> UpdateAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "books/{id}")]
        HttpRequest request,
        [Microsoft.Azure.Functions.Worker.Http.FromBody]
        BookDto dto,
        int id)
    {
        var book = await _burgerBooksDbContext.Books
            .Include(b => b.Authors)
            .Include(b => b.Genre)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            return new NotFoundResult();
        }
        
        var genre = await _burgerBooksDbContext.Genres.FindAsync(dto.GenreId);

        if (genre == null)
        {
            return new BadRequestResult();
        }

        var authors = await _burgerBooksDbContext.Authors
            .Where(a => dto.AuthorIds.Contains(a.Id))
            .ToArrayAsync();

        if (authors.Length < 1)
        {
            return new BadRequestResult();
        }
        
        book.Name = dto.Name;
        book.Published = dto.Published;
        book.Price = dto.Price;
        book.Authors = authors;
        book.Genre = genre;
        
        await _burgerBooksDbContext.SaveChangesAsync();

        _logger.LogInformation("Book updated. Id: {Id}", genre.Id);

        return new OkResult();
    }
    
    [Function("DeleteBook")]
    public async Task<IActionResult> DeleteAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "books/{id}")]
        HttpRequest request,
        int id)
    {
        var book = await _burgerBooksDbContext.Books
            .Include(b => b.BookOrders)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            return new NotFoundResult();
        }

        if (book.BookOrders.Count != 0)
        {
            return new BadRequestResult();
        }

        _burgerBooksDbContext.Books.Remove(book);

        await _burgerBooksDbContext.SaveChangesAsync();
        
        _logger.LogInformation("Book deleted. Id: {Id}", id);
        
        return new OkResult();
    }
}