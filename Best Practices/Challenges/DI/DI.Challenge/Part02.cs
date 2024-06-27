using DI.Challenge.Services;
using DI.Challenge.Services.Interfaces;

namespace DI.Challenge
{
    /// <summary>
    /// This part involves creating a class that depends on ISingletonService.
    /// The class should:
    ///     * Have a private readonly instance of ISingletonService.
    ///     * Accept the ISingletonService instance through the constructor.
    ///     * Call the ISingletonService's DoSingletonStuff method within the Execute method.
    /// </summary>
    public class Part02
    {
        private readonly ISingletonService _singletonService;
        
        public Part02(ISingletonService singletonService)
        {
            _singletonService = singletonService;
        }

        public string Execute()
        {
            return _singletonService.DoSingletonStuff();
        }
    }
}
