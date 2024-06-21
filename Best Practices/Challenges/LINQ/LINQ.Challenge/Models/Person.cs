namespace LINQ.Challenge.Models;

public class Person : IEquatable<Person>
{ 
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int AddressId { get; set; }

    public bool Equals(Person other)
    {
        if (other == null) return false;
        return this.Id == other.Id &&
            this.FirstName == other.FirstName &&
            this.LastName == other.LastName &&
            this.DateOfBirth == other.DateOfBirth &&
            this.AddressId == other.AddressId;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Person);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, FirstName, LastName, DateOfBirth, AddressId);
    }
}
