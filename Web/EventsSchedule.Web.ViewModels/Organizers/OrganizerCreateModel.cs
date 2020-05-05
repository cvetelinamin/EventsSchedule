namespace EventsSchedule.Web.ViewModels.Organizers
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Events;

    public class OrganizerCreateModel : IMapTo<CreateEventInputModel>, IMapFrom<CreateEventInputModel>
    {
        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.OrganizerNameMaxLenght, MinimumLength = AttributesConstraints.OrganizerNameMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.OrganizerContactNameMaxLenght, MinimumLength = AttributesConstraints.OrganizerContactNameMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Лице за контакт")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.OrganizerDescriptionMaxLenght, MinimumLength = AttributesConstraints.OrganizerDescriptionMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Описание")]
        public string OrganizerDescription { get; set; }

        [Display(Name = "Сайт")]
        public string WebSite { get; set; }
    }
}
