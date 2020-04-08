namespace EventsSchedule.Web.ViewModels.News
{
    using System;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class NewsShortViewModel : IMapTo<Blog>, IMapFrom<Blog>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent => this.Content.Substring(0, 200) + "...";

        public DateTime CreatedOn { get; set; }
    }
}
