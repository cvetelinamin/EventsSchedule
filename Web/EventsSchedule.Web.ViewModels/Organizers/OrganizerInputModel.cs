namespace EventsSchedule.Web.ViewModels.Organizers
{
    using System.ComponentModel.DataAnnotations;

    public class OrganizerInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 50)]
        public string Description { get; set; }

        public string WebSite { get; set; }
    }
}
