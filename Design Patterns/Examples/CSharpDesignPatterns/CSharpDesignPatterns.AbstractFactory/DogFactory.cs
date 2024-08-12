using CSharpDesignPatterns.AbstractFactory.Abstraction;
using CSharpDesignPatterns.AbstractFactory.Models;

namespace CSharpDesignPatterns.AbstractFactory;

internal class DogFactory : IAnimalFactory
{
    public IAnimal CreateAnimal()
    {
        return new Dog();
    }

    public IAnimalFood CreateAnimalFood()
    {
        return new DogFood();
    }
}