namespace EventsSchedule.Web.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;
    using EventsSchedule.Data.Common;
    using Microsoft.AspNetCore.Http;

    public class NewsInputModel
    {
        [Required]
        [StringLength(AttributesConstraints.NewsTitleMaxLenght, MinimumLength = AttributesConstraints.NewsTitleMinLenght)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [StringLength(AttributesConstraints.NewsContentMaxLenght, MinimumLength = AttributesConstraints.NewsContentMinLenght)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Снимка")]
        public IFormFile Image { get; set; }
    }
}
