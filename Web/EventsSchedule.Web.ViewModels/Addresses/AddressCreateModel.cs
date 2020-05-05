namespace EventsSchedule.Web.ViewModels.Addresses
{
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Events;

    public class AddressCreateModel : IMapTo<CreateEventInputModel>, IMapFrom<CreateEventInputModel>
    {
        [Required]
        [Display(Name = "Град")]
        public string CityId { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.StreetMaxLenght, MinimumLength = AttributesConstraints.StreetMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Улица №")]
        public string Street { get; set; }

        [Display(Name = "Допълнителна информация")]
        public string AdditionalInformation { get; set; }
    }
}
