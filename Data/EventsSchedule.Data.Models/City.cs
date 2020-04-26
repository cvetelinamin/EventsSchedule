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

        [Required]
        [StringLength(AttributesConstraints.CityNameMaxLenght, MinimumLength = AttributesConstraints.CityNameMinLenght)]
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
