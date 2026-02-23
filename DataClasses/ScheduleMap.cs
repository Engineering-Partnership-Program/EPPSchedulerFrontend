using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using MudBlazor;

namespace EPPSchedulerFrontend.DataClasses;

enum SlotStatus
{
    Scheduled,
    NotScheduled,
}

class ScheduleMap
{
    public required Dictionary<TimeOnly, SlotStatus> sundaySchedule { get; set; }
    public required Dictionary<TimeOnly, SlotStatus> mondaySchedule { get; set; }
    public required Dictionary<TimeOnly, SlotStatus> tuesdaySchedule { get; set; }
    public required Dictionary<TimeOnly, SlotStatus> wednesdaySchedule { get; set; }
    public required Dictionary<TimeOnly, SlotStatus> thursdaySchedule { get; set; }
    public required Dictionary<TimeOnly, SlotStatus> fridaySchedule { get; set; }
    public required Dictionary<TimeOnly, SlotStatus> saturdaySchedule { get; set; }

    [SetsRequiredMembers]
    public ScheduleMap(List<NestedTimeInterval> fullSchedule, List<TimeInterval> shopHours)
    {
        sundaySchedule =
            mondaySchedule =
            tuesdaySchedule =
            wednesdaySchedule =
            thursdaySchedule =
            fridaySchedule =
            saturdaySchedule =
                new Dictionary<TimeOnly, SlotStatus>();
        foreach (TimeInterval currentShopHours in shopHours)
        {
            Dictionary<TimeOnly, SlotStatus> currentScheduleMap =
                new Dictionary<TimeOnly, SlotStatus>();
            for (
                TimeOnly currentTime = currentShopHours.startTime;
                currentTime < currentShopHours.endTime;
                currentTime.AddMinutes(30)
            )
            {
                NestedTimeInterval currentSchedule = fullSchedule.FirstOrDefault(s =>
                    s.day == currentShopHours.day
                );
                if (currentSchedule == null)
                {
                    throw new ArgumentException(
                        $"Not all days are filled in {nameof(fullSchedule)} or there is an incorrect day value in {nameof(shopHours)}"
                    );
                }
                if (currentSchedule.startTimes.Any(p => currentTime >= p && currentTime <= p))
                {
                    currentScheduleMap[currentTime] = SlotStatus.Scheduled;
                }
                else
                {
                    currentScheduleMap[currentTime] = SlotStatus.NotScheduled;
                }
            }
            switch (currentShopHours.day)
            {
                case DayOfWeek.Sunday:
                    sundaySchedule = currentScheduleMap;
                    break;
                case DayOfWeek.Monday:
                    mondaySchedule = currentScheduleMap;
                    break;
                case DayOfWeek.Tuesday:
                    tuesdaySchedule = currentScheduleMap;
                    break;
                case DayOfWeek.Wednesday:
                    wednesdaySchedule = currentScheduleMap;
                    break;
                case DayOfWeek.Thursday:
                    thursdaySchedule = currentScheduleMap;
                    break;
                case DayOfWeek.Friday:
                    fridaySchedule = currentScheduleMap;
                    break;
                case DayOfWeek.Saturday:
                    saturdaySchedule = currentScheduleMap;
                    break;
            }
        }
    }
}
