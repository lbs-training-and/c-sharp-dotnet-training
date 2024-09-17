using BurgerBooks.Function.Database;
using BurgerBooks.Function.Database.Entities;
using BurgerBooks.Function.Features.Genres.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BurgerBooks.Function.Features.Genres;

public class GenreFunctions
{
    private readonly ILogger _logger;
    private readonly BurgerBooksDbContext _burgerBooksDbContext;
    
    public GenreFunctions(ILogger<GenreFunctions> logger, BurgerBooksDbContext burgerBooksDbContext)
    {
        _logger = logger;
        _burgerBooksDbContext = burgerBooksDbContext;
    }

    [Function("CreateGenre")]
    public async Task<IActionResult> CreateAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "genres")]
        HttpRequest request,
        [Microsoft.Azure.Functions.Worker.Http.FromBody]
        GenreDto dto)
    {
        var genre = new Genre
        {
            Name = dto.Name,
            Books = new List<Book>()
        };

        await _burgerBooksDbContext.Genres.AddAsync(genre);

        await _burgerBooksDbContext.SaveChangesAsync();

        _logger.LogInformation("Genre created. Id: {Id}", genre.Id);

        dto.Id = genre.Id;

        return new OkObjectResult(dto);
    }

    [Function("GetGenres")]
    public async Task<IActionResult> GetAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "genres")]
        HttpRequest request)
    {
        var genres = await _burgerBooksDbContext.Genres
            .AsNoTracking()
            .ToArrayAsync();

        var dtos = genres.Select(g => new GenreDto
        {
            Id = g.Id,
            Name = g.Name,
        }).ToArray();

        return new OkObjectResult(dtos);
    }

    [Function("GetGenre")]
    public async Task<IActionResult> GetSingleAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "genres/{id}")]
        HttpRequest request,
        int id)
    {
        var genre = await _burgerBooksDbContext.Genres.FindAsync(id);

        if (genre == null)
        {
            return new NotFoundResult();
        }

        var dto = new GenreDto
        {
            Id = genre.Id,
            Name = genre.Name,
        };
        
        return new OkObjectResult(dto);
    }
    
    [Function("UpdateGenre")]
    public async Task<IActionResult> UpdateAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "genres/{id}")]
        HttpRequest request,
        [Microsoft.Azure.Functions.Worker.Http.FromBody] GenreDto dto,
        int id)
    {
        var genre = await _burgerBooksDbContext.Genres.FindAsync(id);

        if (genre == null)
        {
            return new NotFoundResult();
        }

        genre.Name = dto.Name;

        await _burgerBooksDbContext.SaveChangesAsync();

        _logger.LogInformation("Genre updated. Id: {Id}", genre.Id);

        return new OkResult();
    }
    
    [Function("DeleteGenre")]
    public async Task<IActionResult> DeleteAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "genres/{id}")]
        HttpRequest request,
        int id)
    {
        var genre = await _burgerBooksDbContext.Genres
            .Include(g => g.Books)
            .FirstOrDefaultAsync(g => g.Id == id);
    
        if (genre == null)
        {
            return new NotFoundResult();
        }
        
        if (genre.Books.Count != 0)
        {
            return new BadRequestResult();
        }

        _burgerBooksDbContext.Genres.Remove(genre);

        await _burgerBooksDbContext.SaveChangesAsync();
        
        _logger.LogInformation("Genre deleted. Id: {Id}", id);

        return new OkResult();
    }
}