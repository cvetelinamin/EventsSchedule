namespace EventsSchedule.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EventsSchedule.Data.Common.Models;

    public class Review : BaseDeletableModel<string>
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }

        [Required]
        [MaxLength(250)]
        public string Comment { get; set; }

        [Required]
        public string EventId { get; set; }

        public Event Event { get; set; }
    }
}
