namespace EventsSchedule.Web.ViewModels.Organizers
{
    using System.ComponentModel.DataAnnotations;

    public class OrganizerInputModel
    {
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
