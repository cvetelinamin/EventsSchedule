namespace EventsSchedule.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Common.Models;

    public class News : BaseDeletableModel<string>
    {
        public News()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.NewsTitleMaxLenght, MinimumLength = AttributesConstraints.NewsTitleMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        public string Title { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.NewsContentMaxLenght, MinimumLength = AttributesConstraints.NewsContentMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        public string Content { get; set; }

        public string Image { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
