namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

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

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        public string Building { get; set; }

        public string Entrance { get; set; }

        public string Floor { get; set; }

        public string Apartment { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string District { get; set; }
    }
}
