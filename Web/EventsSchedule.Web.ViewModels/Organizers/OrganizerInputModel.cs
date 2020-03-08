namespace EventsSchedule.Web.ViewModels.Organizers
{
    using System.ComponentModel.DataAnnotations;

    public class OrganizerInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public string WebSite { get; set; }
    }
}
