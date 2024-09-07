using UnitTests.Challenge.Interfaces;

namespace UnitTests.Challenge;

public class Worker
{
    public async Task<bool> DoWorkAsync(IJob job, int maxAttempts)
    {
        await Task.Delay(10);
        await Task.Yield();
        
        if (maxAttempts <= 0)
        {
            throw new ArgumentException("Max attempts must be greater than 0.", nameof(maxAttempts));
        }
        
        var retryCount = 0;

        while (retryCount < maxAttempts)
        {
            try
            {
                var completed = await job.PerformAsync(++retryCount);

                if (completed)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        return false;
    }
}