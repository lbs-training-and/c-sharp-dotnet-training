using DI.Challenge.Services;

namespace DI.Challenge
{
    /// <summary>
    /// This part involves creating a class that depends on SingletonService.
    /// The class should:
    ///     * Have a private readonly instance of SingletonService.
    ///     * Accept the SingletonService instance through the constructor.
    ///     * Call the SingletonService's DoSingletonStuff method within the Execute method.
    /// </summary>
    public class Part01
    {
        private readonly SingletonService _singletonService;
        
        public Part01(SingletonService singletonService)
        {
            _singletonService = singletonService;
        }

        public string Execute()
        {
            return _singletonService.DoSingletonStuff();
        }
    }
}
