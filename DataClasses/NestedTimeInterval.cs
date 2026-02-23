using System.Diagnostics.CodeAnalysis;

namespace EPPSchedulerFrontend.DataClasses;

public class NestedTimeInterval
{
    public required List<TimeOnly> startTimes { get; set; }

    public required List<TimeOnly> endTimes { get; set; }

    public required DayOfWeek day { get; set; }

    [SetsRequiredMembers]
    public NestedTimeInterval(List<TimeOnly> startTimes, List<TimeOnly> endTimes, DayOfWeek day)
    {
        if (startTimes.Count != endTimes.Count)
        {
            throw new ArgumentException("There must be one end time for every start time");
        }

        this.startTimes = startTimes;
        this.endTimes = endTimes;
        this.day = day;
    }

    public NestedTimeInterval() { }
}
