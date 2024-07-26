using UnitTests.Challenge.Exceptions;
using UnitTests.Challenge.Interfaces;

namespace UnitTests.Challenge
{
    /// <summary>
    /// This part involves writing tests for part 5, follow the document for more information
    /// </summary>
    public class CollectionService
    {
        private readonly IDataService _dataService;

        public CollectionService(
            IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task CreateCollectionAsync(string input)
        {
            await _dataService.SaveDataAsync(input);
        }

        public Task<string> GetCollectionAsync(int id)
        {
            return _dataService.GetDataAsync(id);
        }

        public async Task<bool> DeleteCollectionAsync(int id)
        {
            if (await _dataService.GetDataAsync(id) is not null)
            {
                await _dataService.DeleteDataAsync(id);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateCollectionAsync(int id, string input)
        {
            if (await _dataService.GetDataAsync(id) is string savedInput)
            {
                if (!savedInput.Equals(input))
                {
                    await _dataService.SaveDataAsync(input);
                    return true;
                }
            }
            else
            {
                throw new NotFoundException("Could not find the collection to update");
            }

            return false;
        }
    }
}
