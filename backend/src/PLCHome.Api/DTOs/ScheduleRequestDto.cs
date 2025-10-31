using System.ComponentModel.DataAnnotations;

namespace PLCHome.Api.DTOs
{
    public class ScheduleRequestDto
    {
        // Example: time per day in hours, start date, prefer earliest due dates
        public int HoursPerDay { get; set; } = 2;
        public DateTime StartDate { get; set; } = DateTime.UtcNow.Date;
    }
}
