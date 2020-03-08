namespace EventsSchedule.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Models.Enums;

    public class EventInputModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Performer { get; set; }

        public DateTime DoorTime { get; set; }

        public int Duration { get; set; }

        public DateTime EndTime { get; set; }

        [Required]
        [MaxLength(1000)]
        public string EventSchedule { get; set; }

        public EventStatusType Status { get; set; }

        public bool IsAccessibleForFree { get; set; }

        public int MaximumAttendeeCapacity { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public TypicalAgeRange AgeRange { get; set; }
    }
}
