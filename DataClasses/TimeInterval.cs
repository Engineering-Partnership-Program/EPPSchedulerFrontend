namespace EPPSchedulerFrontend.DataClasses;

public class TimeInterval
{
    public DayOfWeek day { get; set; }

    public TimeOnly startTime { get; set; }

    public TimeOnly endTime { get; set; }

    public TimeInterval(DayOfWeek day, TimeOnly startTime, TimeOnly endTime)
    {
        this.day = day;

        this.startTime = startTime;

        this.endTime = endTime;
    }

    public TimeInterval() { }
}
