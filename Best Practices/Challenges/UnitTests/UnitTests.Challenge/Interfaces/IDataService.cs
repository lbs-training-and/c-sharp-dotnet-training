namespace UnitTests.Challenge.Interfaces
{
    public interface IDataService
    {
        Task<string> GetDataAsync(string input);
    }
}
