namespace EventsSchedule.Web.ViewModels.Addresses
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
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
        [StringLength(AttributesConstraints.StreetMaxLenght, MinimumLength = AttributesConstraints.StreetMinLenght)]
        [Display(Name = "Улица №")]
        public string Street { get; set; }

        [Display(Name = "Допълнителна информация")]
        public string AdditionalInformation { get; set; }
    }
}
