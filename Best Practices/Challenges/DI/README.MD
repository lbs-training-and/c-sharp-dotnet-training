# Dependency Injection Challenge

Welcome to the Dependency Injection Challenge! This challenge is designed to test and enhance your knowledge of Dependency Injection (DI) in C#

## Getting Started

1. Clone the Repository: Clone this repository to your local machine. (If you haven't already)
2. Open the Solution: Open the solution file in your preferred IDE (e.g., Visual Studio).
3. Run Tests: Run the unit tests to ensure everything is set up correctly.

## How to Run the Tests

* Navigate to the Test Explorer: In your IDE, navigate to the Test Explorer.
* Run All Tests: Run all the tests to ensure your implementations are correct.

## Challenges
### Part01

Objective: Create a class that depends on SingletonService.

Instructions:
 * Define a private readonly instance of SingletonService.
 * Accept the SingletonService instance through the constructor.
 * Implement the Execute method to call SingletonService's DoSingletonStuff method.

---

### Part02

Objective: Create a class that depends on ISingletonService.

Instructions:
* Define a private readonly instance of ISingletonService.
* Accept the ISingletonService instance through the constructor.
* Implement the Execute method to call ISingletonService's DoSingletonStuff method.

___ 

### Part03

Objective: Register services with their respective lifetimes.

Instructions:
* Register ISingletonService with a singleton lifetime.
* Register IScopedService with a scoped lifetime.
* Register ITransientService with a transient lifetime.

___

### Part04

Objective: Register multiple implementations of IMultipleSingleton.

Instructions:
* Register SingletonA and SingletonB as singletons.
* Ensure both implementations are configured correctly in the dependency injection container.

___

### Part05

Objective: Work with multiple implementations of the ISingletonService interface.

Instructions:
* Accept an IEnumerable<ISingletonService> in the constructor.
* Assign the injected IEnumerable<ISingletonService> to a private readonly field.
* Implement the ExecuteAll method to call the DoSingletonStuff method on each ISingletonService implementation.

---

Good luck with the challenge, and happy coding!

---