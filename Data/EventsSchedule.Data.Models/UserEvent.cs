namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class UserEvent
    {
        [Key]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        public string EventId { get; set; }

        public Event Event { get; set; }

        public int NumberOfGuests { get; set; }
    }
}
