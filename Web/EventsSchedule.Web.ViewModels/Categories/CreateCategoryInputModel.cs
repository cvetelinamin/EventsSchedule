namespace EventsSchedule.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class CreateCategoryInputModel : IMapTo<EventCategory>, IMapFrom<EventCategory>
    {
        [Display(Name = "Име")]
        public string Name { get; set; }
    }
}
