namespace EventsSchedule.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class CategoriesViewModel : IMapTo<EventCategory>, IMapFrom<EventCategory>
    {
        public string Id { get; set; }

        [Display(Name="Име")]
        public string Name { get; set; }
    }
}
