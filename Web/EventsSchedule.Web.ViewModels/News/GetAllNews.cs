namespace EventsSchedule.Web.ViewModels.News
{
    using System.Collections.Generic;

    public class GetAllNews
    {
        public IEnumerable<NewsShortViewModel> News { get; set; }

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }
    }
}
