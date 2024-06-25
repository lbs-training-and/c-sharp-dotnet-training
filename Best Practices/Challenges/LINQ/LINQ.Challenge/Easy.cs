using System.ComponentModel.DataAnnotations;
using LINQ.Challenge.Models;

namespace LINQ.Challenge;

public class Easy
{
    /// <summary>
    /// Retrieves a Person object with the specified Id from a collection of Person objects.
    /// </summary>
    /// <param name="people">An enumerable collection of Person objects.</param>
    /// <param name="id">The Id of the Person to retrieve.</param>
    /// <returns>The Person object with the specified Id.</returns>
    public Person GetPersonById(IEnumerable<Person> people, int id)
    {
        return people.SingleOrDefault(p => p.Id == id);
    }

    /// <summary>
    /// Retrieves a list of Person objects who were born in the specified year.
    /// </summary>
    /// <param name="people">An enumerable collection of Person objects.</param>
    /// <param name="year">The year to filter the birth dates of the people.</param>
    /// <returns>A list of Person objects who were born in the specified year.</returns>
    public List<Person> GetListOfPersonsBornInYear(IEnumerable<Person> people, int year)
    {
        return people.Where(p => p.DateOfBirth.Year == year).ToList();
    }

    /// <summary>
    /// Determines whether any person in the collection was born in the specified year.
    /// </summary>
    /// <param name="people">An enumerable collection of Person objects.</param>
    /// <param name="year">The year to check for in the birth dates of the people.</param>
    /// <returns>True if any person in the collection was born in the specified year; otherwise, false.</returns>
    public bool ListContainsBirthYear(IEnumerable<Person> people, int year)
    {
        return people.Any(p => p.DateOfBirth.Year == year);
    }

    /// <summary>
    /// Retrieves the date of birth of the oldest person from a collection of Person objects.
    /// </summary>
    /// <param name="people">An enumerable collection of Person objects.</param>
    /// <returns>The date of birth of the oldest person in the collection.</returns>
    public DateTime GetOldestPersonDateOfBirth(IEnumerable<Person> people)
    {
        return people.OrderBy(p => p.DateOfBirth).FirstOrDefault().DateOfBirth;
    }

    /// <summary>
    /// Retrieves the date of birth of the youngest person from a collection of Person objects.
    /// </summary>
    /// <param name="people">An enumerable collection of Person objects.</param>
    /// <returns>The date of birth of the youngest person in the collection.</returns>
    public DateTime GetYoungestPersonDateOfBirth(IEnumerable<Person> people)
    {
        return people.OrderByDescending(p => p.DateOfBirth).FirstOrDefault().DateOfBirth;
    }
}