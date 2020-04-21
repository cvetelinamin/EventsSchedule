namespace EventsSchedule.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum EventStatusType
    {
        [Display(Name = "Активно")]
        Active = 1,

        [Display(Name = "Отложено")]
        Cancelled = 2,

        [Display(Name = "Променено")]
        Resheduled = 3,

        [Display(Name = "Приключило")]
        Completed = 4,
    }
}
