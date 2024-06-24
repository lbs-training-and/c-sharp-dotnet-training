using FluentAssertions;

namespace LINQ.Challenge.Tests;

public class IntermediateTests
{
    private Intermediate _intermediateChallenge;

    [SetUp]
    public void SetUp()
    {
        _intermediateChallenge = new Intermediate();
    }

    [Test]
    public void GetSmallestValue_ShouldReturnSmallestValue()
    {
        // Arrange
        var numbers = new List<int> { 3, 1, 5, 11, 9, 0 };
        var expected = 0;

        // Act
        var result = _intermediateChallenge.GetSmallestValue(numbers);

        // Assert
        result.Should().Be(expected);
    }

    [Test]
    public void GetArrayOfEvenNumbers_ShouldReturnOnlyEvenNumbers()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        var expected = new int[] { 2, 4, 6 };

        // Act
        var result = _intermediateChallenge.GetArrayOfEvenNumbers(numbers);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetListOfOrderedNumbersAscending_ShouldReturnNumbersInAscendingOrder()
    {
        // Arrange
        var numbers = new List<int> { 5, 1, 4, 2, 3 };

        // Act
        var result = _intermediateChallenge.GetListOfOrderedNumbersAscending(numbers);

        // Assert
        result.Should().BeInAscendingOrder();
    }

    [Test]
    public void GetListOfOrderedNumbersDescending_ShouldReturnNumbersInDescendingOrder()
    {
        // Arrange
        var numbers = new List<int> { 5, 1, 4, 2, 3 };

        // Act
        var result = _intermediateChallenge.GetListOfOrderedNumbersDescending(numbers);

        // Assert
        result.Should().BeInDescendingOrder();
    }

    [Test]
    public void GetListOfUniqueNumbers_ShouldReturnOnlyUniqueNumbers()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
        var expected = new List<int> { 1, 2, 3, 4, 5 };

        // Act
        var result = _intermediateChallenge.GetListOfUniqueNumbers(numbers);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetValueOfAllOddNumbers_ShouldReturnSumOfAllOddNumbers()
    {
        // Arrange
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var expectedSum = 1 + 3 + 5 + 7 + 9; 

        // Act
        var result = _intermediateChallenge.GetValueOfAllOddNumbers(numbers);

        // Assert
        result.Should().Be(expectedSum);
    }

    [Test]
    public void GetPagedItems_ShouldReturnCorrectPageOfItems()
    {
        // Arrange
        var items = Enumerable.Range(1, 20).ToList();
        var pageNumber = 2;
        var pageSize = 5;
        var expected = new List<int> { 6, 7, 8, 9, 10 };

        // Act
        var result = _intermediateChallenge.GetPagedItems(items, pageNumber, pageSize);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}