namespace CSharpDesignPatterns.Singleton.Models;

internal class Animal
{
    // Private instance, will be created only once
    private static Animal? _instance;
    
    // Any other instance members
    private readonly string _species;

    // Private constructor, so that object can't be instantiated elsewhere
    private Animal(string species)
    {
        _species = species;
    }
    
    // Instance method to control the access to the Singleton object
    internal static Animal Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new Animal("Cat");
            }
            
            return _instance;
        }
    }
    
    // Method for accessing the instance member '_species'
    internal string GetSpecies()
    {
        return _species;
    }
}