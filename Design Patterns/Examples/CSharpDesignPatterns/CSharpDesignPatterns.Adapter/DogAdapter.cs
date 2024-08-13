using CSharpDesignPatterns.Adapter.Abstraction;
using CSharpDesignPatterns.Adapter.Models;

namespace CSharpDesignPatterns.Adapter;

internal class DogAdapter : IAnimal
{
    private readonly Dog _dog;

    internal DogAdapter(Dog dog)
    {
        _dog = dog;
    }

    public void MakeSound()
    {
        _dog.Bark(); // Adapts the Bark method to the MakeSound method
    }
}