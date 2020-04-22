namespace EventsSchedule.Web.ViewModels.Organizers
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class OrganizerEditModel : IMapTo<Organizer>, IMapFrom<Organizer>
    {
        public string Id { get; set; }

        public string EventId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Лице за контакт")]
        public string ContactName { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 50)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Сайт")]
        public string WebSite { get; set; }
    }
}
