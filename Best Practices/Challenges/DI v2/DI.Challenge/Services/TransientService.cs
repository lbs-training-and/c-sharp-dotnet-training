using DI.Challenge.Interfaces;

namespace DI.Challenge.Services
{
    public class TransientService : ITransientService
    {
        public void DoTransientStuff(object work)
        {
            // Do Stuff.
        }
    }
}
