namespace EventsSchedule.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Models.Enums;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Categories;
    using EventsSchedule.Web.ViewModels.Organizers;
    using Microsoft.AspNetCore.Http;

    public class CreateEventModel : IMapTo<OrganizerEditModel>, IMapFrom<OrganizerEditModel>
    {
        public IQueryable<CategoriesViewModel> Categories { get; set; }

        [Required]
        [StringLength(AttributesConstraints.EventTitleMaxLenght, MinimumLength = AttributesConstraints.EventTitleMinLenght)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [StringLength(AttributesConstraints.EventPerformerMaxLenght, MinimumLength = AttributesConstraints.EventPerformerMinLenght)]
        [Display(Name = "Изпълнител")]
        public string Performer { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public string CategoryId { get; set; }

        [Display(Name = "Начало")]
        public DateTime DoorTime { get; set; }

        [Display(Name = "Край")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Статус")]
        public EventStatusType Status { get; set; }

        [Display(Name = "Вход свободен")]
        public bool IsAccessibleForFree { get; set; }

        [Range(AttributesConstraints.EventMinCapacity, AttributesConstraints.EventMaxCapacity)]
        [Display(Name = "Капацитет")]
        public int MaximumAttendeeCapacity { get; set; }

        [Range(AttributesConstraints.EventMinPrice, AttributesConstraints.EventMaxPrice)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(AttributesConstraints.EventDescriptionMaxLenght, MinimumLength = AttributesConstraints.EventDescriptionMinLenght)]
        [Display(Name = "Описание на събитието")]
        public string Description { get; set; }

        [Display(Name = "Възраст")]
        public TypicalAgeRange AgeRange { get; set; }

        [Display(Name = "Снимка")]
        public IFormFile Image { get; set; }

        [Required]
        [StringLength(AttributesConstraints.OrganizerNameMaxLenght, MinimumLength = AttributesConstraints.OrganizerNameMinLenght)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [StringLength(AttributesConstraints.OrganizerContactNameMaxLenght, MinimumLength = AttributesConstraints.OrganizerContactNameMinLenght)]
        [Display(Name = "Лице за контакт")]
        public string ContactName { get; set; }

        [Required]
        [StringLength(AttributesConstraints.OrganizerDescriptionMaxLenght, MinimumLength = AttributesConstraints.OrganizerDescriptionMinLenght)]
        [Display(Name = "Описание")]
        public string OrganizerDescription { get; set; }

        [Display(Name = "Сайт")]
        public string WebSite { get; set; }

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
