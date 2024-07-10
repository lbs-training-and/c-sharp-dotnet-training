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
### Part 01

Objective: Register a singleton class.

Instructions:
* Register the SingletonService class.
* Be registered as itself.
* Not use abstraction as the type.
* Be a singleton.

---

### Part 02

Objective: Register a singleton class with an abstraction.

Instructions:
* Register the SingletonService class.
* Use the ISingletonService abstraction as the type.
* Be a singleton.

___ 

### Part 03

Objective: Register classes for the Transient and Scoped lifetimes.

Instructions:
* Register the TransientService and ScopedService classes.
* Use their respective abstractions as the type.
* Be registered under the correct lifetime.

___

### Part 04

Objective: Register multiple implementations of a type.

Instructions:
* Register the FaxNotificationService, SmsNotificationService and EmailNotificationService services.
* Use the INotificationService as the abstraction.
* Use singleton as the lifetime.

___

### Part 05

Objective: Take a dependency on a type.

Instructions:
* Register the SingletonConsumerService using the ISingletonConsumerService type as a singleton.
* Take a dependency on the ISingletonService through the constructor.
* Call the ISingletonService's DoSingletonStuff method in the DoWork method.

---

### Part 06

Objective: Take a dependency on multiple types.

Instructions:
* Register the ConsumerService using the IConsumerService type as a transient.
* Take a dependency on the ISingletonService, IScopedService and ITransientService through the constructor.
* Call each of the service's methods in the DoWork method.

---

### Part 07

Objective: Take a dependency on multiple implementations of a type.

Instructions:
* Register the OrderService using the IOrderService type as a scoped lifetime.
* Take a dependency on all implementations of INotificationService.
* Call INotificationService's SendDispatched method in the Dispatch method.

---

Good luck with the challenge, and happy coding!

---