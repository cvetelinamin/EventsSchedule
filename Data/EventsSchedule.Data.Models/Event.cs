﻿namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Common.Models;
    using EventsSchedule.Data.Models.Enums;

    public class Event : BaseDeletableModel<string>
    {
        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Audience = new HashSet<UserEvent>();
            this.Reviews = new HashSet<Review>();
        }

        [Required]
        [StringLength(AttributesConstraints.EventTitleMaxLenght, MinimumLength = AttributesConstraints.EventTitleMinLenght)]
        public string Title { get; set; }

        [Required]
        [StringLength(AttributesConstraints.EventPerformerMaxLenght, MinimumLength = AttributesConstraints.EventPerformerMinLenght)]
        public string Performer { get; set; }

        [Required]
        public string OrganizerId { get; set; }

        public Organizer Organizer { get; set; }

        [Required]
        public string EventCategoryId { get; set; }

        public EventCategory EventCategory { get; set; }

        public int Rating { get; set; }

        public DateTime DoorTime { get; set; }

        public DateTime EndTime { get; set; }

        public EventStatusType Status { get; set; }

        public bool IsAccessibleForFree { get; set; }

        [Required]
        public string AddressId { get; set; }

        public Address Address { get; set; }

        [Range(AttributesConstraints.EventMinCapacity, AttributesConstraints.EventMaxCapacity)]
        public int MaximumAttendeeCapacity { get; set; }

        [Range(AttributesConstraints.EventMinPrice, AttributesConstraints.EventMaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(AttributesConstraints.EventDescriptionMaxLenght, MinimumLength = AttributesConstraints.EventDescriptionMinLenght)]
        public string Description { get; set; }

        public string CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }

        public TypicalAgeRange AgeRange { get; set; }

        public string Image { get; set; }

        public ICollection<UserEvent> Audience { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
