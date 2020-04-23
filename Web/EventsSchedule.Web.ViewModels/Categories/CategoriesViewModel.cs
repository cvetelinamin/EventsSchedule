namespace EventsSchedule.Web.ViewModels.Categories
{
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class CategoriesViewModel : IMapTo<EventCategory>, IMapFrom<EventCategory>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
