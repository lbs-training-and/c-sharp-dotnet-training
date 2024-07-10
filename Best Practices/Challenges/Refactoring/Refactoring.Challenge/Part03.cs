namespace Refactoring.Challenge;

/// <summary>
/// This part involves refactoring a method that concatinates different datetimes
/// The Run method should:
///     * Be refactored to use a simpler solution.
///     * Not break the existing test.
/// </summary>
public class Part03
{
    public string Run(DateTime startDate, DateTime endDate, DateTime renewalDate)
    {
        string formattedStartDate = startDate.Day.ToString("00") + "-" + startDate.Month.ToString("00") + "-" + startDate.Year.ToString("0000");
        var formattedEndDate = endDate.Day.ToString("00") + "-" + endDate.Month.ToString("00") + "-" + endDate.Year.ToString("0000");
        string formattedRenewalDate = renewalDate.Day.ToString("00") + "-" + renewalDate.Month.ToString("00") + "-" + renewalDate.Year.ToString("0000");

        return "Start Date: " + formattedStartDate + ", End Date: " + formattedEndDate + ", Renewal Date: " + formattedRenewalDate;
    }
}