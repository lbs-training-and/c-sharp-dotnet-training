using CSharpDesignPatterns.AbstractFactory.Abstraction;
using CSharpDesignPatterns.AbstractFactory.Models;

namespace CSharpDesignPatterns.AbstractFactory;

internal class CatFactory : IAnimalFactory
{
    public IAnimal CreateAnimal()
    {
        return new Cat();
    }

    public IAnimalFood CreateAnimalFood()
    {
        return new CatFood();
    }
}