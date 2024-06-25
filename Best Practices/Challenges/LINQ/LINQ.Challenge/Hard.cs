using LINQ.Challenge.Models;
using LINQ.Challenge.Models.DTOs;

namespace LINQ.Challenge;

public class Hard
{
    /// <summary>
    /// Retrieves the Person object with the highest Id from a collection of Person objects.
    /// </summary>
    /// <param name="people">An enumerable collection of Person objects.</param>
    /// <returns>The Person object with the highest Id.</returns>
    public Person GetPersonWithHigestId(IEnumerable<Person> people)
    {
        //return people.OrderByDescending(p => p.Id).FirstOrDefault();
        return people.MaxBy(p => p.Id);
    }

    /// <summary>
    /// Groups a collection of Person objects by their last names and returns a list of these groups.
    /// </summary>
    /// <param name="people">An enumerable collection of Person objects.</param>
    /// <returns>A list of lists, where each inner list contains Person objects that share the same last name.</returns>
    public List<List<Person>> ListOfPeopleGroupedByLastName(IEnumerable<Person> people)
    {
        return people
            .GroupBy(p => p.LastName)
            .Select(p => p.ToList())
            .ToList();
    }

    /// <summary>
    /// Joins a collection of Person objects with a collection of Address objects based on AddressId,
    /// and converts the joined data into a list of PersonDto objects, with a populated AddressDto
    /// </summary>
    /// <param name="people">An enumerable collection of Person objects.</param>
    /// <param name="addresses">An enumerable collection of Address objects.</param>
    /// <returns>A list of PersonDto objects created by joining the Person and Address collections.</returns>
    public List<PersonDto> JoinPeopleAndAddresses(IEnumerable<Person> people, IEnumerable<Address> addresses)
    {
        return people.Join(addresses, p => p.AddressId, a => a.Id, (p, a) => new PersonDto {
            FirstName = p.FirstName,
            LastName = p.LastName,
            DateOfBirth = p.DateOfBirth,
            Address = new AddressDto {
                StreetName = a.StreetName,
                City = a.City,
                PostalCode = a.PostalCode,
                Country = a.Country
            }
        }).ToList();
    }

    /// <summary>
    /// Converts a collection of unique Person objects to a list of PersonDto objects.
    /// AddressDto can be initialised as default
    /// </summary>
    /// <param name="people">An enumerable collection of Person objects.</param>
    /// <returns>A list of unique PersonDto objects converted from the provided Person collection.</returns>
    public List<PersonDto> GetUniquePeopleAsDto(IEnumerable<Person> people)
    {
        return people
            .Distinct()
            .Select(p => new PersonDto {
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Address = new AddressDto()
            }).ToList();
    }

    /// <summary>
    /// Retrieves a list of unique first names of people who are older than the specified age, ordered alphabetically.
    /// </summary>
    /// <param name="people">An enumerable collection of Person objects.</param>
    /// <param name="age">The age threshold for filtering people.</param>
    /// <returns>A list of unique first names of people older than the specified age, ordered alphabetically.</returns>
    public List<string> GetUniqueOrderedFirstNamesOfPeopleOverAge(IEnumerable<Person> people, int age)
    {
        return people
            .Where(p => DateTime.Today.Year - p.DateOfBirth.Year > age)
            .Select(p => p.FirstName)
            .Distinct()
            .OrderBy(p => p).ToList();
    }
}