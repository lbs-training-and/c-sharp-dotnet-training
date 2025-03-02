using CSharpDesignPatterns.MethodFactory.Models;

namespace CSharpDesignPatterns.MethodFactory;

internal class AnimalFactory
{
    internal Animal CreateAnimal(string animalType)
    {
        return animalType.ToLower() switch
        {
            "cat" => new Cat(),
            "dog" => new Dog(),
            _ => throw new ArgumentException("Invalid animal type")
        };
    }
}