namespace EventsSchedule.Web.ViewModels.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Data.Models.Enums;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Categories;

    public class EventInputModel : IMapTo<Event>, IMapFrom<Event>
    {
        public IQueryable<CategoriesViewModel> Categories { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Performer { get; set; }

        [Required]
        public string CategoryId { get; set; }

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
        public string Description { get; set; }

        public TypicalAgeRange AgeRange { get; set; }
    }
}
