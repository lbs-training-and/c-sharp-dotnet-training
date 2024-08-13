using CSharpDesignPatterns.Decorator;
using CSharpDesignPatterns.Decorator.Models;

// Create a simple dog
var dog = new Dog();

// Decorate the dog to be loud
var loudDog = new LoudAnimalDecorator(dog);

// Decorate the dog to be playful
var playfulDog = new PlayfulAnimalDecorator(dog);

// Decorate the dog to be both loud and playful
var loudPlayfulDog = new PlayfulAnimalDecorator(loudDog);

// Make sounds
Console.WriteLine("Simple Dog:");
dog.MakeSound();               // Output: The dog says: Woof.

Console.WriteLine("\nLoud Dog:");
loudDog.MakeSound();           // Output: Loudly, The dog says: Woof.

Console.WriteLine("\nPlayful Dog:");
playfulDog.MakeSound();        // Output: Playfully, The dog says: Woof.

Console.WriteLine("\nLoud and Playful Dog:");
loudPlayfulDog.MakeSound();    // Output: Playfully, Loudly, The dog says: Woof.