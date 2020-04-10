namespace EventsSchedule.Web.ViewModels.News
{
    using System;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;
    using Ganss.XSS;

    public class NewsViewModel : IMapFrom<Blog>, IMapTo<Blog>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string ApplicationUserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Image { get; set; }
    }
}
