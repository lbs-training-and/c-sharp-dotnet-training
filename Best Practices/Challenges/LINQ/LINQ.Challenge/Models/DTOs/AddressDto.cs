namespace LINQ.Challenge.Models.DTOs;


/// <summary>
/// The AddressDto class serves as a Data Transfer Object (DTO) for the Address class.
/// It is used to transfer data between processes, simplifying serialisation and deserialisation 
/// without exposing the entire Address entity, which might contain additional logic or properties 
/// not necessary for data transfer.
/// </summary>
public class AddressDto
{
    public string StreetName { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}
