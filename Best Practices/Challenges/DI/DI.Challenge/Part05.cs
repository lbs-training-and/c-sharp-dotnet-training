namespace DI.Challenge
{
    /// <summary>
    /// This part involves working with multiple implementations of the ISingletonService interface.
    /// The class should:
    ///     * Accept an IEnumerable<ISingletonService> in the constructor.
    ///     * Assign the injected IEnumerable<ISingletonService> to a private readonly field.
    ///     * Implement the ExecuteAll method to call the DoSingletonStuff method on each ISingletonService implementation.
    /// </summary>
    public class Part05
    {
        public Part05(object fix)
        {
        }

        public void ExecuteAll()
        {
            throw new NotImplementedException();
        }
    }
}
