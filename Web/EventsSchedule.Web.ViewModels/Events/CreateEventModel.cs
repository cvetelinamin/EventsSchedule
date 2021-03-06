﻿namespace EventsSchedule.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;

    public class CreateEventModel
    {
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
        public string CategoryId { get; set; }

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
    }
}
