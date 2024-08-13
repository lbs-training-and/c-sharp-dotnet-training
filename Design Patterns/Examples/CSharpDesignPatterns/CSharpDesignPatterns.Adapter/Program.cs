using CSharpDesignPatterns.Adapter;
using CSharpDesignPatterns.Adapter.Models;

// Create instances of Cat and Dog
var cat = new Cat();
var dog = new Dog();

// Create adapters for Cat and Dog
var catAdapter = new CatAdapter(cat);
var dogAdapter = new DogAdapter(dog);

// Use the adapters to interact with Cat and Dog
// through the unified IAnimal interface
catAdapter.MakeSound(); // Output: The cat says: Meow!
dogAdapter.MakeSound(); // Output: The dog says: Woof!