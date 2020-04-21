namespace EventsSchedule.Web.ViewModels.Addresses
{
    using System.ComponentModel.DataAnnotations;

    public class AddressInputModel
    {
        [Required]
        [Display(Name = "Град")]
        public string CityId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Улица №")]
        public string Street { get; set; }

        [Display(Name = "Допълнителна информация")]
        public string AdditionalInformation { get; set; }
    }
}
