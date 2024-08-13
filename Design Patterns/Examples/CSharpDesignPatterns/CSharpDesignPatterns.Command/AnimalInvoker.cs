using CSharpDesignPatterns.Command.Abstraction;

namespace CSharpDesignPatterns.Command;

internal class AnimalInvoker
{
    private IAnimalCommand _command;

    internal void SetCommand(IAnimalCommand command)
    {
        _command = command;
    }

    internal void ExecuteCommand()
    {
        _command.Execute();
    }
}