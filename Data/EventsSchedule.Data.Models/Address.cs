namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Common.Models;

    public class Address : BaseDeletableModel<string>
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string CityId { get; set; }

        public City City { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.StreetMaxLenght, MinimumLength = AttributesConstraints.StreetMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        public string Street { get; set; }

        public string AdditionalInformation { get; set; }
    }
}
