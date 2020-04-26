namespace EventsSchedule.Web.ViewModels.Events
{
    using System;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;
    using Ganss.XSS;

    public class EventIndexViewModel : IMapTo<Event>, IMapFrom<Event>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);

        public string ShortDescription => this.SanitizedDescription.Length > 100 ? this.SanitizedDescription.Substring(0, 100) + "..." : this.SanitizedDescription;
    }
}
