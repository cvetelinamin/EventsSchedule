namespace EventsSchedule.Web.ViewModels.Reviews
{
    using AutoMapper;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;
    using Ganss.XSS;
    using System;

    public class EventReviewViewModel : IMapFrom<Review>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public string SanitizedComment => new HtmlSanitizer().Sanitize(this.Comment);

        public string EventId { get; set; }

        public string EventTitle { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<Review, EventReviewViewModel>()
               .ForMember(
                           destination => destination.Username,
                           opts => opts.MapFrom(origin => origin.ApplicationUser.UserName));
        }
    }
}
