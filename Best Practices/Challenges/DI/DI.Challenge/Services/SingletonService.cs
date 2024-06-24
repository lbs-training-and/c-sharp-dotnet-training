using DI.Challenge.Services.Interfaces;

namespace DI.Challenge.Services
{
    public class SingletonService : ISingletonService
    {
        public const string SingletonCalled = "SingletonCalled";
        public string DoSingletonStuff()
        {
            return SingletonCalled;
        }
    }
}
