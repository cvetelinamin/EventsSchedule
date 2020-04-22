namespace EventsSchedule.Web.ViewModels.Addresses
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class AddressEditModel : IMapTo<Address>, IMapFrom<Address>
    {
        public string Id { get; set; }

        public string EventId { get; set; }

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
