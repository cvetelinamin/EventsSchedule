namespace EventsSchedule.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class TopEventViewModel : IMapTo<Event>, IMapFrom<Event>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Performer { get; set; }

        public EventCategory EventCategory { get; set; }

        public DateTime DoorTime { get; set; }

        public int Duration { get; set; }

        public int MaximumAttendeeCapacity { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
