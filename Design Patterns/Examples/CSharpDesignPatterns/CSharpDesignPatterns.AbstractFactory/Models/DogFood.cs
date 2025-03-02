using CSharpDesignPatterns.AbstractFactory.Abstraction;

namespace CSharpDesignPatterns.AbstractFactory.Models;

internal class DogFood : IAnimalFood
{
    public string GetFoodName()
    {
        return "Howlin' Chow";
    }
}