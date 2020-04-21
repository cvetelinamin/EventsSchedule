namespace EventsSchedule.Web.ViewModels.Home
{
    using EventsSchedule.Data.Models.Enums;

    public class IndexInputModel
    {
        public string EventCategoryId { get; set; }

        public EventsPriceSort PriceSort { get; set; }

        public string CityId { get; set; }

        public TypicalAgeRange TypicalAgeRangeSort { get; set; }

        public int? PagesCount { get; set; }

        public int? CurrentPage { get; set; }
    }
}
