namespace CSharpDesignPatterns.AbstractFactory.Abstraction;

internal interface IAnimalFactory
{
    IAnimal CreateAnimal();

    IAnimalFood CreateAnimalFood();
}