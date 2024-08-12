using CSharpDesignPatterns.AbstractFactory.Abstraction;

namespace CSharpDesignPatterns.AbstractFactory.Models;

internal class CatFood : IAnimalFood
{
    public string GetFoodName()
    {
        return "Purrrfectly Posh Nosh";
    }
}