using FluentAssertions;

namespace Refactoring.Challenge.Tests
{
    [TestFixture]
    public class Part03Tests
    {
        [Test]
        public void Run_WithValidDates_ReturnsFormattedString()
        {
            // Arrange
            var part = new Part03();
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 12, 31);
            var renewalDate = new DateTime(2025, 1, 1);

            // Act
            var result = part.Run(startDate, endDate, renewalDate);

            //Assert
            var expectedFormat = $"Start Date: {startDate:dd-MM-yyyy}, End Date: {endDate:dd-MM-yyyy}, Renewal Date: {renewalDate:dd-MM-yyyy}";

            result.Should().Match(expectedFormat);
        }
    }
}
