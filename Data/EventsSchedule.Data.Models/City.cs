namespace EventsSchedule.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using EventsSchedule.Data.Common.Models;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Addresses = new HashSet<Address>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
