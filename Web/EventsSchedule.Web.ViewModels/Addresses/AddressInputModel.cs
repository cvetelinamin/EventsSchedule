﻿namespace EventsSchedule.Web.ViewModels.Addresses
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Models;

    public class AddressInputModel
    {
        public City CityName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Street { get; set; }

        [Required]
        [Range(0, 1000)]
        public string Number { get; set; }

        public string Building { get; set; }

        public string Entrance { get; set; }

        public string Floor { get; set; }

        public string Apartment { get; set; }

        [Required]
        public string District { get; set; }
    }
}
