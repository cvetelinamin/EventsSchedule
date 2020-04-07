namespace EventsSchedule.Web.ViewModels.News
{
    using System;

    public class NewsShortViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent => this.Content.Substring(0, 200) + "...";

        public DateTime CreatedOn { get; set; }
    }
}
