namespace EventsSchedule.Web.ViewModels.News
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using Microsoft.AspNetCore.Http;

    public class NewsInputModel
    {
        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.NewsTitleMaxLenght, MinimumLength = AttributesConstraints.NewsTitleMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.NewsContentMaxLenght, MinimumLength = AttributesConstraints.NewsContentMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [Display(Name = "Снимка")]
        public IFormFile Image { get; set; }
    }
}
