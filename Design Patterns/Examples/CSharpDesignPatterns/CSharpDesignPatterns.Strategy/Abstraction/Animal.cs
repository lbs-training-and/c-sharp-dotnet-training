namespace CSharpDesignPatterns.Strategy.Abstraction;

internal abstract class Animal
{
    private IAnimalBehaviour _behavior;

    private protected Animal(IAnimalBehaviour behavior)
    {
        _behavior = behavior;
    }

    internal void SetBehavior(IAnimalBehaviour behavior)
    {
        _behavior = behavior;
    }

    internal void PerformInteract()
    {
        _behavior.Interact();
    }

    internal abstract void DisplayAnimalType();
}