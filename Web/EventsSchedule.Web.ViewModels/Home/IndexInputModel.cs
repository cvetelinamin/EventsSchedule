namespace EventsSchedule.Web.ViewModels.Home
{
    using EventsSchedule.Data.Models.Enums;

    public class IndexInputModel
    {
        public string EventCategoryId { get; set; }

        public EventsPriceSort Sort { get; set; }

        public string CityId { get; set; }
    }
}
