using CSharpDesignPatterns.Facade;
using CSharpDesignPatterns.Facade.Models;

// Create a Dog instance
var dog = new Dog("Scooter");

// Use the DogCareFacade to simplify dog care operations
var dogCareFacade = new DogCareFacade();
        
// Care for the dog
dogCareFacade.CareForDog(dog);

// Output:
// Scooter is being fed.
// Scooter is going for a walk.
// Scooter is getting a haircut.