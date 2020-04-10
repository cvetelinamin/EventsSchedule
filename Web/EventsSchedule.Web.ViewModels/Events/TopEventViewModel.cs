namespace EventsSchedule.Web.ViewModels.Events
{
    using System;
    using System.Text.RegularExpressions;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;
    using Ganss.XSS;

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

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public string ShortDescription => this.SanitizedDescription.Length > 100 ? this.SanitizedDescription.Substring(0, 100) + "..." : this.SanitizedDescription;
    }
}
