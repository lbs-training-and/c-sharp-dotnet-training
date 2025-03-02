using CSharpDesignPatterns.Adapter.Abstraction;
using CSharpDesignPatterns.Adapter.Models;

namespace CSharpDesignPatterns.Adapter;

internal class CatAdapter : IAnimal
{
    private readonly Cat _cat;

    internal CatAdapter(Cat cat)
    {
        _cat = cat;
    }

    public void MakeSound()
    {
        _cat.Meow(); // Adapts the Meow method to the MakeSound method
    }
}