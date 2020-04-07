using System;
using System.Collections.Generic;
using System.Text;

namespace EventsSchedule.Web.ViewModels.News
{
    public class GetAllNews
    {
        public IEnumerable<NewsShortViewModel> News { get; set; }

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }
    }
}
