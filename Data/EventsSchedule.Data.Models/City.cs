namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Common.Models;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Addresses = new HashSet<Address>();
        }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.CityNameMaxLenght, MinimumLength = AttributesConstraints.CityNameMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
