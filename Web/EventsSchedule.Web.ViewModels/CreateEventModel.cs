namespace EventsSchedule.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Data.Models.Enums;

    public class CreateEventModel
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

        public EventStatusType Status { get; set; }

        public bool IsAccessibleForFree { get; set; }

        [Range(0, 50000)]
        public int MaximumAttendeeCapacity { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(1500)]
        public string EventDescription { get; set; }

        public TypicalAgeRange AgeRange { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 50)]
        public string OrganizerDescription { get; set; }

        public string WebSite { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Street { get; set; }

        [Required]
        [Range(0, 1000)]
        public string Number { get; set; }

        public string Building { get; set; }

        public string Entrance { get; set; }

        public string Floor { get; set; }

        public string Apartment { get; set; }

        [Required]
        public string District { get; set; }
    }
}
