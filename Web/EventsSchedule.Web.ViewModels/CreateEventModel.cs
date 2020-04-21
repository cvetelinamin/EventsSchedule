namespace EventsSchedule.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using EventsSchedule.Data.Models.Enums;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Categories;
    using EventsSchedule.Web.ViewModels.Organizers;
    using Microsoft.AspNetCore.Http;

    public class CreateEventModel : IMapTo<OrganizerInputModel>, IMapFrom<OrganizerInputModel>
    {
        public IQueryable<CategoriesViewModel> Categories { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Изпълнител")]
        public string Performer { get; set; }

        [Required]
        [Display(Name = "Категория")]
        public string CategoryId { get; set; }

        [Display(Name = "Начало")]
        public DateTime DoorTime { get; set; }

        [Display(Name = "Продължителност")]
        [Range(30, 300)]
        public int Duration { get; set; }

        [Display(Name = "Край")]
        public DateTime EndTime { get; set; }

        [Required]
        [MaxLength(1000)]
        [Display(Name = "График на събитието")]
        public string EventSchedule { get; set; }

        [Display(Name = "Статус")]
        public EventStatusType Status { get; set; }

        [Display(Name = "Вход свободен")]
        public bool IsAccessibleForFree { get; set; }

        [Range(0, 50000)]
        [Display(Name = "Капацитет")]
        public int MaximumAttendeeCapacity { get; set; }

        [Range(0, 10000)]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(1500)]
        [Display(Name = "Допълнително описание")]
        public string Description { get; set; }

        [Display(Name = "Възраст")]
        public TypicalAgeRange AgeRange { get; set; }

        [Display(Name = "Снимка")]
        public IFormFile Image { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Лице за контакт")]
        public string ContactName { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 50)]
        [Display(Name = "Описание")]
        public string OrganizerDescription { get; set; }

        [Display(Name = "Сайт")]
        public string WebSite { get; set; }

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
