using UnitTests.Challenge.Interfaces;

namespace UnitTests.Challenge;

public class Worker
{
    public async Task DoWorkAsync(IJob job, int maxAttempts)
    {
        var retryCount = 0;

        while (retryCount < maxAttempts)
        {
            var completed = await job.PerformAsync(++retryCount);

            if (completed)
            {
                break;
            }
        }
    }
}