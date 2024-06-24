namespace LINQ.Challenge.Models.DTOs;

/// <summary>
/// The PersonDto class serves as a Data Transfer Object (DTO) for the Person class.
/// It is used to transfer data between processes, simplifying serialisation and deserialisation 
/// without exposing the entire Person entity, which might contain additional logic or properties 
/// not necessary for data transfer.
/// </summary>
public class PersonDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public AddressDto Address { get; set; }
}
