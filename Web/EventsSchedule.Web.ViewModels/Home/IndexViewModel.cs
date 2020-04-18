﻿namespace EventsSchedule.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels.Events;

    public class IndexViewModel
    {
        public IEnumerable<EventCategory> Categories { get; set; }

        public IEnumerable<EventShortViewModel> Events { get; set; }

        public string EventCategoryId { get; set; }
    }
}
