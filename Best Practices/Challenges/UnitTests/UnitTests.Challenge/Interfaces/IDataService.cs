namespace UnitTests.Challenge.Interfaces
{
    public interface IDataService
    {
        Task SaveDataAsync(string input);
        Task<string> GetDataAsync(int id);
        Task<string> UpdateDataAsync(int id, string input);
        Task DeleteDataAsync(int id);
    }
}
