# Asynchronous Programming Challenge

Welcome to the Asynchronous Programming Challenge!\
This challenge is designed to test and enhance your knowledge of asynchronous programming in C#.

## Getting Started

1. Clone the Repository: Clone this repository to your local machine. (If you haven't already)
2. Open the Solution: Open the solution file in your preferred IDE (e.g., Visual Studio).
3. Run Tests: Run the unit tests to ensure everything is set up correctly.

## How to Run the Tests

* Navigate to the Test Explorer: In your IDE, navigate to the Test Explorer.
* Run All Tests: Run all the tests to ensure your implementations are correct.

## Challenges
### Part 01

Objective: Initiate and await an async method.

Instructions:
* Return a type of Task.
* Be marked as async.
* Await the IOrderRepository.SaveAsync() method.

---

### Part 02

Objective: Initiate, but don't await the async method.

Instructions:
* Return a type of Task.
* Return the task from IOrderRepository.SaveAsync() method.

---

### Part 03

Objective: Initiate, await and return the response from an async method.

Instructions:
* Return a type of Task{Order}.
* Be marked as async.
* Await the IOrderRepository.GetAsync() method.
* Return the result of the IOrderRepository.GetAsync() method.

---

### Part 04

Objective: Initiate, but don't await the async method that returns an order.

Instructions:
* Return a type of Task{Order}.
* Return the task from IOrderRepository.GetAsync() method.

---

### Part 05

Objective: Await multiple async methods and throw an exception.

Instructions:
* Like previous parts, update the method signature to handle scenario.
* Call the IOrderRepository.GetAsync() method.
* If the order is null, throw a OrderNotFoundException.
* If the order is not null, call the IOrderRepository.DeleteAsync() method.

---

### Part 06

Objective: Await multiple async methods and throw an exception.

Instructions:
* Like previous parts, update the method signature to handle scenario.
* Get the order using the id.
* If the order is null, throw a OrderNotFoundException.
* If the order is not null:
  * Update its status to the supplied.
  * Send a notification from all the INotificationService objects and await the completion before invoking the next.

---

### Part 07

Objective: Await multiple async methods in order and handle exceptions.

Instructions:
* Send a notification from each INotificationService and await the completion before invoking the next.
* Use a try catch to ensure a faulty notification service doesn't prevent the others from sending
* Log an error for any exceptions that are caught. The message can be anything you like, but the log must include the exception.

---

### Part 08

Objective: Concurrently run two async methods.

Instructions:
* Send a notification from each INotificationService concurrently.
* Await the completion of each notification.

---

### Part 09

Objective: Concurrently run multiple async methods.

Instructions:
* Send a notification from each INotificationService concurrently.
* Await the completion of each notification.
* **HINT** - A method already exists to await all tasks.

---

### Part 10

Objective: Concurrently run multiple async methods and return the result from which completed first.

Instructions:
* Make each racer race concurrently.
* Return the result of the racer that finished first.
* **HINT** - A method already exists to do this.

---

### Part 11

Objective: Concurrently run multiple async methods and handle exceptions

Instructions:
* Send a notification from each INotificationService concurrently.
* Await each notification task.
* Use a try catch to ensure a faulty notification service doesn't prevent the others from being awaited.
* Log an error for any exceptions that are caught. The message can be anything you like, but the log must include the exception.

---

Good luck with the challenge, and happy coding!

---