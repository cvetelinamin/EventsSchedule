namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using EventsSchedule.Data.Common.Models;

    public class EventCategory : BaseDeletableModel<string>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
