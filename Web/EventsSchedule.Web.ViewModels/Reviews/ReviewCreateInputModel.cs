namespace EventsSchedule.Web.ViewModels.Reviews
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class ReviewCreateInputModel : IMapTo<Review>, IMapFrom<Review>
    {
        [Range(AttributesConstraints.MinRaiting, AttributesConstraints.MaxRaiting, ErrorMessage = AttributesErrorMessages.RaitingErrorMessage)]
        [Display(Name = "Оценка")]
        public int Rating { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.CommentMaxLenght, MinimumLength = AttributesConstraints.CommentMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Коментар")]
        public string Comment { get; set; }

        public string EventId { get; set; }
    }
}
