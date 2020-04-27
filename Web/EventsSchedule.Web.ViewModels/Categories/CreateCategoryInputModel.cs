namespace EventsSchedule.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class CreateCategoryInputModel : IMapTo<EventCategory>, IMapFrom<EventCategory>
    {
        [Display(Name = "Име")]
        [StringLength(AttributesConstraints.CategoryNameMaxLenght, MinimumLength = AttributesConstraints.CategoryNameMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        public string Name { get; set; }
    }
}
