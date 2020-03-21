namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using EventsSchedule.Data.Common.Models;
    using EventsSchedule.Data.Models.Enums;

    public class Event : BaseDeletableModel<string>
    {
        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Audience = new HashSet<UserEvent>();
        }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Performer { get; set; }

        [Required]
        public string OrganizerId { get; set; }

        public Organizer Organizer { get; set; }

        [Required]
        public string EventCategoryId { get; set; }

        public EventCategory EventCategory { get; set; }

        public int Rating { get; set; }

        public DateTime DoorTime { get; set; }

        public int Duration { get; set; }

        public DateTime EndTime { get; set; }

        [Required]
        [MaxLength(1000)]
        public string EventSchedule { get; set; }

        public EventStatusType Status { get; set; }

        public bool IsAccessibleForFree { get; set; }

        [Required]
        public string AddressId { get; set; }

        public Address Address { get; set; }

        public int MaximumAttendeeCapacity { get; set; }

        public decimal Price { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }

        public string CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }

        public TypicalAgeRange AgeRange { get; set; }

        public ICollection<UserEvent> Audience { get; set; }
    }
}
