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
            this.Addresses = new HashSet<Address>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public string WebSite { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
