namespace EventsSchedule.Web.ViewModels.Reviews
{
    using System;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;
    using Ganss.XSS;

    public class EventReviewViewModel : IMapFrom<Review>
    {
        public string Id { get; set; }

        public string ApplicationUserUserName { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public string SanitizedComment => new HtmlSanitizer().Sanitize(this.Comment);

        public string EventId { get; set; }

        public string EventTitle { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
