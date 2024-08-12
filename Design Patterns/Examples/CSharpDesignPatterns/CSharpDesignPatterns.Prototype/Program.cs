using CSharpDesignPatterns.Prototype.Models;

// Create instance of Cat
// For the sake of the example, assume
// that the creation process is timely/expensive
var cat = new Cat("Domestic Cat");

// Once we have the first Cat, we can
// clone it to save that time/cost.
// i.e.
var clonedCat = (Cat)cat.Clone();

// To demonstrate the cloning worked, we can output
// their species; they should both be the same species:
Console.WriteLine($"This cat is a '{cat.GetSpecies()}'"); // Output: This cat is a 'Domestic Cat'
Console.WriteLine($"This cat is a '{clonedCat?.GetSpecies()}'"); // Output: This cat is a 'Domestic Cat'