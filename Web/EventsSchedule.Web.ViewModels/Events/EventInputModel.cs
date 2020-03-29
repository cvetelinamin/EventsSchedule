namespace EventsSchedule.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Data.Models.Enums;
    using EventsSchedule.Services.Mapping;

    public class EventInputModel : IMapTo<Event>, IMapFrom<Event>
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Performer { get; set; }

        [Required]
        public EventCategory Category { get; set; }

        public DateTime DoorTime { get; set; }

        [Range(30, 300)]
        public int Duration { get; set; }

        public DateTime EndTime { get; set; }

        [Required]
        [MaxLength(1000)]
        public string EventSchedule { get; set; }

        public string Status { get; set; }

        public bool IsAccessibleForFree { get; set; }

        [Range(0, 50000)]
        public int MaximumAttendeeCapacity { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public string AgeRange { get; set; }
    }
}
