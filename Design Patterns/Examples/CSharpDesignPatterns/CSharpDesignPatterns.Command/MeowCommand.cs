using CSharpDesignPatterns.Command.Abstraction;
using CSharpDesignPatterns.Command.Models;

namespace CSharpDesignPatterns.Command;

internal class MeowCommand : IAnimalCommand
{
    private readonly Cat _cat;

    internal MeowCommand(Cat cat)
    {
        _cat = cat;
    }
    
    public void Execute()
    {
        _cat.Meow();
    }
}