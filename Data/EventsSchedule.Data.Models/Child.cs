namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EventsSchedule.Data.Common.Models;
    using EventsSchedule.Data.Models.Enums;

    public class Child : BaseDeletableModel<string>
    {
        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
