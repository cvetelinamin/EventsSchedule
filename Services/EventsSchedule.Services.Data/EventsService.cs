namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels;
    using EventsSchedule.Web.ViewModels.Events;

    public class EventsService : IEventsService
    {
        private readonly ICategoryService categoryService;

        public EventsService(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<Event> CreatEvent(CreateEventModel model, string userId, Organizer organizer, Address address)
        {
            var eventToCreate = new Event
            {
                Title = model.Title,
                Performer = model.Performer,
                DoorTime = model.DoorTime,
                EndTime = model.EndTime,
                Duration = model.Duration,
                Description = model.EventDescription,
                EventSchedule = model.EventSchedule,
                MaximumAttendeeCapacity = model.MaximumAttendeeCapacity,
                IsAccessibleForFree = model.IsAccessibleForFree,
                Price = model.Price,
                CreatorId = userId,
                Organizer = organizer,
                Status = model.Status,
                AgeRange = model.AgeRange,
                Address = address,
                EventCategoryId = await this.categoryService.GetIdByTitleAsync(model.Category.Name),
            };

            return eventToCreate;
        }
    }
}
