namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using EventsSchedule.Data.Common.Models;

    public class Organizer : BaseDeletableModel<string>
    {
        public Organizer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Events = new HashSet<Event>();
        }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Description { get; set; }

        public string WebSite { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
