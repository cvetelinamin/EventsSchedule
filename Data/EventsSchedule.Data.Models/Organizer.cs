namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common;
    using EventsSchedule.Data.Common.Models;

    public class Organizer : BaseDeletableModel<string>
    {
        public Organizer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Events = new HashSet<Event>();
        }

        [Required]
        [StringLength(AttributesConstraints.OrganizerNameMaxLenght, MinimumLength = AttributesConstraints.OrganizerNameMinLenght)]
        public string Name { get; set; }

        [Required]
        [StringLength(AttributesConstraints.OrganizerContactNameMaxLenght, MinimumLength = AttributesConstraints.OrganizerContactNameMinLenght)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(AttributesConstraints.OrganizerDescriptionMaxLenght, MinimumLength = AttributesConstraints.OrganizerDescriptionMinLenght)]
        public string Description { get; set; }

        public string WebSite { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
