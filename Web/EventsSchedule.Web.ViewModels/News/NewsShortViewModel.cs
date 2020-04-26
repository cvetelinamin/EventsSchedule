namespace EventsSchedule.Web.ViewModels.News
{
    using System;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class NewsShortViewModel : IMapTo<News>, IMapFrom<News>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent => this.Content.Length > 200 ? this.Content.Substring(0, 200) + "..." : this.Content;

        public DateTime CreatedOn { get; set; }

        public string Image { get; set; }
    }
}
