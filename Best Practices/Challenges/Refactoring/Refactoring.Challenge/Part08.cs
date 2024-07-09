namespace Refactoring.Challenge
{
    /// <summary>
    /// This part involves refactoring a method that calculates statistics on a list of numbers.
    /// The Run method should:
    ///     * Be refactored to use a simpler solution.
    ///     * Not break the existing test.
    ///     * HINT - break down into smaller relevant methods
    /// </summary>
    /// </summary>
    public class Part08
    {
        public (double, double, double) CalculateStats(List<int> nums)
        {
            if (nums == null || nums.Count == 0)
            {
                throw new ArgumentException("List is null or empty");
            }

            double mean = 0;
            double median = 0;
            double mode = 0;

            int sum = 0;
            foreach (var num in nums)
            {
                sum += num;
            }
            mean = (double)sum / nums.Count;

            nums.Sort();
            if (nums.Count % 2 == 0)
            {
                median = (nums[nums.Count / 2 - 1] + nums[nums.Count / 2]) / 2.0;
            }
            else
            {
                median = nums[nums.Count / 2];
            }

            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                }
                else
                {
                    counts[num] = 1;
                }
            }

            int maxCount = 0;
            foreach (var kvp in counts)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    mode = kvp.Key;
                }
            }

            return (mean, median, mode);
        }
    }
}
