namespace EventsSchedule.Web.ViewModels.Events
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Data.Models.Enums;
    using EventsSchedule.Services.Mapping;

    public class EventViewModel : IMapFrom<Event>, IMapTo<Event>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Performer { get; set; }

        public Organizer Organizer { get; set; }

        public EventCategory EventCategory { get; set; }

        public int Rating { get; set; }

        public DateTime DoorTime { get; set; }

        public int Duration { get; set; }

        public DateTime EndTime { get; set; }

        public string EventSchedule { get; set; }

        public EventStatusType Status { get; set; }

        public bool IsAccessibleForFree { get; set; }

        public string Address { get; set; }

        public int MaximumAttendeeCapacity { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ApplicationUser UserUserName { get; set; }

        public TypicalAgeRange AgeRange { get; set; }

        public int AudienceCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(x => x.AudienceCount, options =>
                {
                    options.MapFrom(p => p.Audience.Count);
                });
        }
    }
}
