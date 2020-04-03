﻿namespace EventsSchedule.Web.ViewModels.Reviews
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class ReviewCreateInputModel : IMapTo<Review>, IMapFrom<Review>
    {
        [Range(0, 5)]
        public int Rating { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comment { get; set; }

        public string EventId { get; set; }
    }
}
