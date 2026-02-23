namespace EPPSchedulerFrontend.DataClasses;

public class EmployeeProfile
{
    public required string email { get; set; }
    public required string name { get; set; }
    public required string school { get; set; }
    public required int experience { get; set; }
    public required string year { get; set; }
    public required int requestedHours { get; set; }
    public required bool workWithFab { get; set; }
    public required List<NestedTimeInterval> preferredHours { get; set; }
    public required List<NestedTimeInterval> allHours { get; set; }
    public List<NestedTimeInterval>? finalSchedule { get; set; }
}
