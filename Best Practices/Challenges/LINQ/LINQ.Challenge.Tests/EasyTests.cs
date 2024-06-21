using FluentAssertions;
using LINQ.Challenge.Models;

namespace LINQ.Challenge.Tests;

public class EasyTests
{
    private List<Person> _personList;
    private Easy _easyChallenge; 

    [SetUp]
    public void SetUp()
    {
        _personList = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1993, 1, 1) },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(1993, 2, 2) },
            new Person { Id = 3, FirstName = "Bob", LastName = "Smith", DateOfBirth = new DateTime(1999, 3, 3) },
            new Person { Id = 4, FirstName = "Alice", LastName = "Brown", DateOfBirth = new DateTime(1999, 4, 4) },
            new Person { Id = 5, FirstName = "Charlie", LastName = "Smith", DateOfBirth = new DateTime(1999, 5, 5) }
        };

        _easyChallenge = new Easy();
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void GetPersonById_ShouldReturnCorrectPerson(int id)
    {
        // Act
        var result = _easyChallenge.GetPersonById(_personList, id);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(id);
    }

    [Test]
    [TestCase(1993)]
    [TestCase(1999)]
    public void GetListOfPersonsBornInYear_ShouldReturnCorrectPersons(int year)
    {
        // Act
        var result = _easyChallenge.GetListOfPersonsBornInYear(_personList, year);

        // Assert
        result.Should().NotBeNull();
        result.Should().OnlyContain(p => p.DateOfBirth.Year == year);
    }

    [Test]
    [TestCase(1993, true)]
    [TestCase(1999, true)]
    [TestCase(2000, false)]
    public void ListContainsBirthYear_ShouldReturnCorrectResult(int year, bool expectedResult)
    {
        // Act
        var result = _easyChallenge.ListContainsBirthYear(_personList, year);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    public void GetOldestPersonDateOfBirth_ShouldReturnOldestPersonDateOfBirth()
    {
        // Act
        var result = _easyChallenge.GetOldestPersonDateOfBirth(_personList);

        // Assert
        result.Should().Be(new DateTime(1993, 1, 1));
    }

    [Test]
    public void GetYoungestPersonDateOfBirth_ShouldReturnYoungestPersonDateOfBirth()
    {
        // Act
        var result = _easyChallenge.GetYoungestPersonDateOfBirth(_personList);

        // Assert
        result.Should().Be(new DateTime(1999, 5, 5));
    }
}