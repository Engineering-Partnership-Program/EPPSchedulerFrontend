using System.Diagnostics.CodeAnalysis;

namespace EPPSchedulerFrontend.DataClasses;

public class ScheduleProfile
{
    public required Guid scheduleProfileId { get; set; }
    public required bool active { get; set; }
    public required bool manual { get; set; }
    public bool? pairByExperience { get; set; }
    public int? maxConcurrentEmployees { get; set; }
    public float? maxTotalHours { get; set; }
    public float? minTotalHours { get; set; }
    public float? maxHoursPerEmployee { get; set; }
    public required List<TimeInterval> shopHours { get; set; }
    public List<NestedTimeInterval>? fabTimes { get; set; }

    [SetsRequiredMembers]
    public ScheduleProfile(
        Guid scheduleProfileId,
        bool active,
        bool manual,
        List<TimeInterval> shopHours
    )
    {
        this.scheduleProfileId = scheduleProfileId;
        this.active = active;
        this.manual = manual;
        this.shopHours = shopHours;
    }

    [SetsRequiredMembers]
    public ScheduleProfile(
        Guid scheduleProfileId,
        bool active,
        bool manual,
        bool pairByExperience,
        int maxConcurrentEmployees,
        float maxTotalHours,
        float minTotalHours,
        float maxHoursPerEmployee,
        List<TimeInterval> shopHours,
        List<NestedTimeInterval> fabTimes
    )
    {
        this.scheduleProfileId = scheduleProfileId;
        this.active = active;
        this.manual = manual;
        this.pairByExperience = pairByExperience;
        this.maxTotalHours = maxTotalHours;
        this.maxConcurrentEmployees = maxConcurrentEmployees;
        this.minTotalHours = minTotalHours;
        this.maxHoursPerEmployee = maxHoursPerEmployee;
        this.shopHours = shopHours;
        this.fabTimes = fabTimes;
    }
}
