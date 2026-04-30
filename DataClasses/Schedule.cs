using System.Diagnostics.CodeAnalysis;

namespace EPPSchedulerFrontend.DataClasses;

public class Schedule
{
    public required Dictionary<EmployeeProfile, List<NestedTimeInterval>> schedule { get; set; }

    [SetsRequiredMembers]
    public Schedule(Dictionary<EmployeeProfile, List<NestedTimeInterval>> schedule)
    {
        this.schedule = schedule;
    }

    public Schedule() { }
}
