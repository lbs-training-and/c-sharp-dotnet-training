using CSharpDesignPatterns.MethodFactory;

var factory = new AnimalFactory();

var dog = factory.CreateAnimal("Dog");
dog.Speak(); // Output: Woof!

var cat = factory.CreateAnimal("Cat");
cat.Speak(); // Output: Meow!