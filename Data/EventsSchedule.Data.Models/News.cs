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

        [Required]
        [StringLength(AttributesConstraints.NewsTitleMaxLenght, MinimumLength = AttributesConstraints.NewsTitleMinLenght)]
        public string Title { get; set; }

        [Required]
        [StringLength(AttributesConstraints.NewsContentMaxLenght, MinimumLength = AttributesConstraints.NewsContentMinLenght)]
        public string Content { get; set; }

        public string Image { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
