using CSharpDesignPatterns.Command.Abstraction;
using CSharpDesignPatterns.Command.Models;

namespace CSharpDesignPatterns.Command;

internal class BarkCommand : IAnimalCommand
{
    private readonly Dog _dog;

    internal BarkCommand(Dog dog)
    {
        _dog = dog;
    }

    public void Execute()
    {
        _dog.Bark();
    }
}