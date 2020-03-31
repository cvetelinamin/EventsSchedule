namespace EventsSchedule.Web.ViewModels.Blogs
{
    using System.ComponentModel.DataAnnotations;

    public class BlogInputModel
    {
        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Content { get; set; }
    }
}
