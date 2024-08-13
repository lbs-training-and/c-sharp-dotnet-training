using CSharpDesignPatterns.Facade.Models;
using CSharpDesignPatterns.Facade.Services;

namespace CSharpDesignPatterns.Facade;

internal class DogCareFacade
{
    private readonly FeedingService _feedingService;
    private readonly WalkingService _walkingService;
    private readonly GroomingService _groomingService;

    internal DogCareFacade()
    {
        _feedingService = new FeedingService();
        _walkingService = new WalkingService();
        _groomingService = new GroomingService();
    }

    internal void CareForDog(Dog dog)
    {
        _feedingService.Feed(dog);
        _walkingService.Walk(dog);
        _groomingService.Groom(dog);
    }
}