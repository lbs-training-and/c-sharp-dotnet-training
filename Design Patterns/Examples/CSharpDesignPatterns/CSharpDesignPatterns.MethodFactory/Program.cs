// See https://aka.ms/new-console-template for more information

using CSharpDesignPatterns.MethodFactory;
using CSharpDesignPatterns.MethodFactory.Models;

AnimalFactory factory = new AnimalFactory();

Animal dog = factory.CreateAnimal("Dog");
dog.Speak(); // Output: Woof!

Animal cat = factory.CreateAnimal("Cat");
cat.Speak(); // Output: Meow!