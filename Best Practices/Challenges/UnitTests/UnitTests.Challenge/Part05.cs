using Microsoft.Extensions.Logging;
using UnitTests.Challenge.Interfaces;

namespace UnitTests.Challenge
{
    /// <summary>
    /// This part involves writing tests for part 5, follow the document for more information
    /// </summary>
    public class Part05
    {
        private readonly IDataService _dataService;
        private readonly ILogger<Part05> _logger;

        public Part05(
            IDataService dataService,
            ILogger<Part05> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public async Task<string> CollectDataAsync(string input)
        {
            try
            {
                var data = await _dataService.GetDataAsync(input);
                return data;
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured");
                throw;
            }
        }
    }
}
