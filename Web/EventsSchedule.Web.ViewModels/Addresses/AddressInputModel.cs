namespace EventsSchedule.Web.ViewModels.Addresses
{
    using System.ComponentModel.DataAnnotations;

    public class AddressInputModel
    {
        [Required]
        public string CityId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Street { get; set; }

        public string AdditionalInformation { get; set; }
    }
}
