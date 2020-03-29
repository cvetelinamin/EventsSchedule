namespace EventsSchedule.Web.ViewModels.Reviews
{
    using AutoMapper;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class ReviewViewModel : IMapTo<Review>, IMapFrom<Review>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public string EventId { get; set; }

        public string EventTitle { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<Review, ReviewViewModel>()
               .ForMember(
                           destination => destination.Username,
                           opts => opts.MapFrom(origin => origin.ApplicationUser.UserName));
        }
    }
}
