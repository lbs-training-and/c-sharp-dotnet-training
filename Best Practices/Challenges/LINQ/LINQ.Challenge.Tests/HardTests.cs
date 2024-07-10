using FluentAssertions;
using LINQ.Challenge.Models;
using LINQ.Challenge.Models.DTOs;

namespace LINQ.Challenge.Tests;

public class HardTests
{
    private Hard _hardChallenge;

    [SetUp]
    public void SetUp()
    {
        _hardChallenge = new Hard();
    }

    [Test]
    public void GetPersonWithHighestId_ShouldReturnPersonWithHighestId()
    {
        // Arrange
        var people = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1) },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(1985, 2, 2) },
            new Person { Id = 3, FirstName = "Bob", LastName = "Smith", DateOfBirth = new DateTime(1990, 3, 3) },
            new Person { Id = 4, FirstName = "Alice", LastName = "Brown", DateOfBirth = new DateTime(1985, 4, 4) },
            new Person { Id = 5, FirstName = "Charlie", LastName = "Smith", DateOfBirth = new DateTime(1992, 5, 5) }
        };

        // Act
        var person = _hardChallenge.GetPersonWithHigestId(people);

        // Assert
        person.Should().NotBeNull();
        person.Id.Should().Be(5);
    }

    [Test]
    public void ListOfPeopleGroupedByLastName_ShouldGroupPeopleByLastName()
    {

        // Arrange
        var people = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1) },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(1985, 2, 2) },
            new Person { Id = 3, FirstName = "Bob", LastName = "Smith", DateOfBirth = new DateTime(1990, 3, 3) },
            new Person { Id = 4, FirstName = "Alice", LastName = "Brown", DateOfBirth = new DateTime(1985, 4, 4) },
            new Person { Id = 5, FirstName = "Charlie", LastName = "Smith", DateOfBirth = new DateTime(1992, 5, 5) }
        };

        // Act
        var groupedPeople = _hardChallenge.ListOfPeopleGroupedByLastName(people);

        // Assert
        groupedPeople.Should().NotBeNull();
        groupedPeople.Should().HaveCount(3);

        var doeGroup = groupedPeople.SingleOrDefault(g => g.Key == "Doe");
        doeGroup.Should().NotBeNull();
        doeGroup.Should().HaveCount(2);
        doeGroup.Should().Contain(p => p.FirstName == "John" && p.LastName == "Doe");
        doeGroup.Should().Contain(p => p.FirstName == "Jane" && p.LastName == "Doe");

        var smithGroup = groupedPeople.SingleOrDefault(g => g.Key == "Smith");
        smithGroup.Should().HaveCount(2);
        smithGroup.Should().Contain(p => p.FirstName == "Bob" && p.LastName == "Smith");
        smithGroup.Should().Contain(p => p.FirstName == "Charlie" && p.LastName == "Smith");

        var brownGroup = groupedPeople.SingleOrDefault(g => g.Key == "Brown");
        brownGroup.Should().NotBeNull();
        brownGroup.Should().HaveCount(1);
        brownGroup.Should().Contain(p => p.FirstName == "Alice" && p.LastName == "Brown");
    }

    [Test]
    public void JoinPeopleAndAddresses_ShouldReturnJoinedList()
    {
        // Arrange
        var people = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1), AddressId = 1 },
            new Person { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1985, 5, 23), AddressId = 2 }
        };

        var addresses = new List<Address>
        {
            new Address { Id = 1, StreetName = "Greek St", City = "Leeds", PostalCode = "LS1 5SH", Country = "UK" },
            new Address { Id = 2, StreetName = "Commercial St", City = "Leeds", PostalCode = "LS1 6EX", Country = "UK" }
        };

        var expected = new List<PersonDto>
        {
            new PersonDto
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Address = new AddressDto
                {
                    StreetName = "Greek St",
                    City = "Leeds",
                    PostalCode = "LS1 5SH",
                    Country = "UK"
                }
            },
            new PersonDto
            {
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateTime(1985, 5, 23),
                Address = new AddressDto
                {
                    StreetName = "Commercial St",
                    City = "Leeds",
                    PostalCode = "LS1 6EX",
                    Country = "UK"
                }
            }
        };

        // Act
        var result = _hardChallenge.JoinPeopleAndAddresses(people, addresses);

        // Assert
        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public void GetUniquePeopleAsDto_ShouldReturnUniquePeopleAsDto()
    {
        // Arrange
        var people = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 1) },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(1990, 2, 2) },
            new Person { Id = 3, FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1985, 3, 3) },
            new Person { Id = 3, FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1985, 3, 3) },
            new Person { Id = 4, FirstName = "Bob", LastName = "Brown", DateOfBirth = new DateTime(1982, 4, 4) }
        };
        var expectedDtos = new List<PersonDto>
        {
            new PersonDto { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 1), Address = new AddressDto() },
            new PersonDto { FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(1990, 2, 2), Address = new AddressDto() },
            new PersonDto { FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1985, 3, 3), Address = new AddressDto() },
            new PersonDto { FirstName = "Bob", LastName = "Brown", DateOfBirth = new DateTime(1982, 4, 4), Address = new AddressDto() }
        };

        // Act
        var result = _hardChallenge.GetUniquePeopleAsDto(people);

        // Assert
        result.Should().BeEquivalentTo(expectedDtos);
    }

    [Test]
    public void GetUniqueOrderedFirstNameOfPeopleOverAge_ShouldReturnUniqueOrderedFirstNamesOfPeopleOverGivenAge()
    {
        // Arrange
        var people = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 1) },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateTime(1990, 2, 2) },
            new Person { Id = 3, FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1985, 3, 3) },
            new Person { Id = 4, FirstName = "Bob", LastName = "Brown", DateOfBirth = new DateTime(1982, 4, 4) },
            new Person { Id = 5, FirstName = "Alice", LastName = "Johnson", DateOfBirth = new DateTime(1985, 5, 5) }
        };

        int age = 30;
        var expectedFirstNames = new List<string> { "Alice", "Bob", "Jane", "John" };

        // Act
        var result = _hardChallenge.GetUniqueOrderedFirstNamesOfPeopleOverAge(people, age);

        // Assert
        result.Should().BeEquivalentTo(expectedFirstNames, options => options.WithStrictOrdering());
    }
}
