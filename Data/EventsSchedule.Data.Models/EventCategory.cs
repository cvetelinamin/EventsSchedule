namespace EventsSchedule.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Common.Models;

    public class EventCategory : BaseDeletableModel<string>
    {
        public EventCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.CategoryNameMaxLenght, MinimumLength = AttributesConstraints.CategoryNameMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        public string Name { get; set; }
    }
}
