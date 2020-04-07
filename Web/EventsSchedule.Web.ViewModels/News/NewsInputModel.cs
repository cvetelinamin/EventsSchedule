namespace EventsSchedule.Web.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;

    public class NewsInputModel
    {
        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Content { get; set; }
    }
}
