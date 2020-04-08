namespace EventsSchedule.Web.ViewModels.News
{
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class NewsEditViewModel : IMapTo<Blog>, IMapFrom<Blog>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
