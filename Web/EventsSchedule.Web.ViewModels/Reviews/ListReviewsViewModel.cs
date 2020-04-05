namespace EventsSchedule.Web.ViewModels.Reviews
{
    using System.Collections.Generic;

    public class ListReviewsViewModel
    {
        public IEnumerable<EventReviewViewModel> EventReviews { get; set; }

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }

        public string EventId { get; set; }
    }
}
