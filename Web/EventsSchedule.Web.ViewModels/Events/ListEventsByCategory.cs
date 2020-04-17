namespace EventsSchedule.Web.ViewModels.Events
{
    using System.Collections.Generic;

    public class ListEventsByCategory
    {
        public IEnumerable<EventShortViewModel> Events { get; set; }
    }
}
