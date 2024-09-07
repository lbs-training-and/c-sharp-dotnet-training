// using FluentAssertions;
//
// namespace UnitTesting.Examples.Tests;
//
// [TestFixture]
// public class NumberValidatorTests
// {
//     [Test]
//     [TestCase("1", true)]
//     [TestCase("2.55", true)]
//     [TestCase("", false)]
//     [TestCase("zero", false)]
//     [TestCase("hello", false)]
//     public void CanValidateCorrectNumber(
//         string potentialNumber, bool expected)
//     {
//         // Arrange
//
//         var validator = new NumberValidator();
//
//         // Act
//
//         var isValidNumber = validator.IsValid(potentialNumber);
//
//         // Assert
//
//         isValidNumber.Should().Be(expected);
//     }
// }
//
//
//
// // [Test]
// // public void CanValidateCorrectNumber()
// // {
// //     // Arrange
// //
// //     const string number = "2.55";
// //
// //     var validator = new NumberValidator();
// //
// //     // Act
// //
// //     var isValidNumber = validator.IsValid(number);
// //
// //     // Assert
// //
// //     isValidNumber.Should().Be(true);
// // }
