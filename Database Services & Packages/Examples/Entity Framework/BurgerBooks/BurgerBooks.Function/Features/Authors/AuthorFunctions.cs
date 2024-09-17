using BurgerBooks.Function.Database;
using BurgerBooks.Function.Database.Entities;
using BurgerBooks.Function.Features.Authors.Models;
using BurgerBooks.Function.Features.Genres.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BurgerBooks.Function.Features.Authors;

public class AuthorFunctions
{
    private readonly ILogger _logger;
    private readonly BurgerBooksDbContext _burgerBooksDbContext;


    public AuthorFunctions(ILogger<AuthorFunctions> logger, BurgerBooksDbContext burgerBooksDbContext)
    {
        _logger = logger;
        _burgerBooksDbContext = burgerBooksDbContext;
    }

    [Function("CreateAuthor")]
    public async Task<IActionResult> CreateAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "authors")]
        HttpRequest request,
        [Microsoft.Azure.Functions.Worker.Http.FromBody]
        AuthorDto dto)
    {
        var author = new Author
        {
            Name = dto.Name,
            Books = new List<Book>()
        };

        await _burgerBooksDbContext.Authors.AddAsync(author);

        await _burgerBooksDbContext.SaveChangesAsync();

        _logger.LogInformation("Author created. Id: {Id}", author.Id);

        return new OkObjectResult(new IdDto(author.Id));
    }

    [Function("GetAuthors")]
    public async Task<IActionResult> GetAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "authors")]
        HttpRequest request)
    {
        var authors = await _burgerBooksDbContext.Authors
            .AsNoTracking()
            .ToArrayAsync();

        var dtos = authors.Select(g => new AuthorDto
        {
            Id = g.Id,
            Name = g.Name,
        }).ToArray();

        return new OkObjectResult(dtos);
    }

    [Function("GetAuthor")]
    public async Task<IActionResult> GetSingleAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "authors/{id}")]
        HttpRequest request,
        int id)
    {
        var author = await _burgerBooksDbContext.Authors.FindAsync(id);

        if (author == null)
        {
            return new NotFoundResult();
        }

        var dto = new GenreDto
        {
            Id = author.Id,
            Name = author.Name,
        };
        
        return new OkObjectResult(dto);
    }
    
    [Function("UpdateAuthor")]
    public async Task<IActionResult> UpdateAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "authors/{id}")]
        HttpRequest request,
        [Microsoft.Azure.Functions.Worker.Http.FromBody] AuthorDto dto,
        int id)
    {
        var author = await _burgerBooksDbContext.Authors.FindAsync(id);

        if (author == null)
        {
            return new NotFoundResult();
        }

        author.Name = dto.Name;

        await _burgerBooksDbContext.SaveChangesAsync();

        _logger.LogInformation("Author updated. Id: {Id}", author.Id);

        return new OkResult();
    }
    
    [Function("DeleteAuthor")]
    public async Task<IActionResult> DeleteAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "authors/{id}")]
        HttpRequest request,
        int id)
    {
        var author = await _burgerBooksDbContext.Authors
            .Include(g => g.Books)
            .FirstOrDefaultAsync(g => g.Id == id);
    
        if (author == null)
        {
            return new NotFoundResult();
        }

        if (author.Books.Count != 0)
        {
            return new BadRequestResult();
        }

        _burgerBooksDbContext.Authors.Remove(author);

        await _burgerBooksDbContext.SaveChangesAsync();
        
        _logger.LogInformation("Author deleted. Id: {Id}", id);

        return new OkResult();
    }
}