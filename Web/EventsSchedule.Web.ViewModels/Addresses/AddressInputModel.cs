namespace EventsSchedule.Web.ViewModels.Addresses
{
    using System.ComponentModel.DataAnnotations;

    public class AddressInputModel
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        public string Building { get; set; }

        public string Entrance { get; set; }

        public string Floor { get; set; }

        public string Apartment { get; set; }

        [Required]
        public string District { get; set; }
    }
}
