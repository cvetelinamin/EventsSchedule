namespace EventsSchedule.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Data.Models.Enums;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Categories;
    using EventsSchedule.Web.ViewModels.Organizers;
    using Microsoft.AspNetCore.Http;

    public class CreateEventInputModel : IMapTo<OrganizerEditModel>, IMapFrom<OrganizerEditModel>,
                                         IMapTo<Organizer>, IMapFrom<Organizer>,
                                         IMapTo<Address>, IMapFrom<Address>,
                                         IMapTo<Event>, IMapFrom<Event>
    {
        public IQueryable<CategoriesViewModel> Categories { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.EventTitleMaxLenght, MinimumLength = AttributesConstraints.EventTitleMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.EventPerformerMaxLenght, MinimumLength = AttributesConstraints.EventPerformerMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Изпълнител")]
        public string Performer { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [Display(Name = "Категория")]
        public string EventCategoryId { get; set; }

        [Display(Name = "Начало")]
        public DateTime DoorTime { get; set; }

        [Display(Name = "Край")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Статус")]
        public EventStatusType Status { get; set; }

        [Display(Name = "Вход свободен")]
        public bool IsAccessibleForFree { get; set; }

        [Range(AttributesConstraints.EventMinCapacity, AttributesConstraints.EventMaxCapacity, ErrorMessage = AttributesErrorMessages.CapacityErrorMessage)]
        [Display(Name = "Капацитет")]
        public int MaximumAttendeeCapacity { get; set; }

        [Range(AttributesConstraints.EventMinPrice, AttributesConstraints.EventMaxPrice, ErrorMessage = AttributesErrorMessages.PriceErrorMessage)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.EventDescriptionMaxLenght, MinimumLength = AttributesConstraints.EventDescriptionMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Описание на събитието")]
        public string Description { get; set; }

        [Display(Name = "Възраст")]
        public TypicalAgeRange AgeRange { get; set; }

        [Display(Name = "Снимка")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.OrganizerNameMaxLenght, MinimumLength = AttributesConstraints.OrganizerNameMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.OrganizerContactNameMaxLenght, MinimumLength = AttributesConstraints.OrganizerContactNameMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Лице за контакт")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = AttributesErrorMessages.RequiredErrorMessage)]
        [StringLength(AttributesConstraints.OrganizerDescriptionMaxLenght, MinimumLength = AttributesConstraints.OrganizerDescriptionMinLenght, ErrorMessage = AttributesErrorMessages.StringLengthErrorMessage)]
        [Display(Name = "Описание")]
        public string OrganizerDescription { get; set; }

        [Display(Name = "Сайт")]
        public string WebSite { get; set; }

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
