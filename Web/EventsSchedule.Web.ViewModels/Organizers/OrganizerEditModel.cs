namespace EventsSchedule.Web.ViewModels.Organizers
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class OrganizerEditModel : IMapTo<Organizer>, IMapFrom<Organizer>
    {
        public string Id { get; set; }

        public string EventId { get; set; }

        [Required]
        [StringLength(AttributesConstraints.OrganizerNameMaxLenght, MinimumLength = AttributesConstraints.OrganizerNameMinLenght)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [StringLength(AttributesConstraints.OrganizerContactNameMaxLenght, MinimumLength = AttributesConstraints.OrganizerContactNameMinLenght)]
        [Display(Name = "Лице за контакт")]
        public string ContactName { get; set; }

        [Required]
        [StringLength(AttributesConstraints.OrganizerDescriptionMaxLenght, MinimumLength = AttributesConstraints.OrganizerDescriptionMinLenght)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Сайт")]
        public string WebSite { get; set; }
    }
}
