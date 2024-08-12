using CSharpDesignPatterns.Singleton.Models;

// Get the single instance of Animal
var singleAnimalInstance = Animal.Instance;

// Use the methods of the singleton instance
Console.WriteLine($"The animal species is: {singleAnimalInstance.GetSpecies()}");