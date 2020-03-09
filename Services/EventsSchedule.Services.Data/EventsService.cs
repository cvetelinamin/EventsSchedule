namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels.Events;

    public class EventsService : IEventsService
    {
        public Event CreatEvent(EventInputModel model, string userId, Organizer organizer)
        {
            var eventToCreate = new Event
            {
                Title = model.Title,
                Performer = model.Performer,
                DoorTime = model.DoorTime,
                EndTime = model.EndTime,
                Duration = model.Duration,
                Description = model.Description,
                EventSchedule = model.EventSchedule,
                MaximumAttendeeCapacity = model.MaximumAttendeeCapacity,
                IsAccessibleForFree = model.IsAccessibleForFree,
                Price = model.Price,
                CreatorId = userId,
                Organizer = organizer,
                Status = model.Status,
                AgeRange = model.AgeRange,
            };

            return eventToCreate;
        }
    }
}
