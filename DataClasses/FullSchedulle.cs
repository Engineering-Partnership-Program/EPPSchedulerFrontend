using System.Diagnostics.CodeAnalysis;

namespace EPPSchedulerFrontend.DataClasses;

public class FullSchedule
{
    public required string name { get; set; }
    public required Guid scheduleProfileId { get; set; }
    public Schedule? fullSchedule { get; set; }

    [SetsRequiredMembers]
    public FullSchedule(string name, Guid scheduleProfileId, Schedule? fullSchedule)
    {
        this.name = name;
        this.scheduleProfileId = scheduleProfileId;
        this.fullSchedule = fullSchedule;
    }

    public FullSchedule() { }
}
