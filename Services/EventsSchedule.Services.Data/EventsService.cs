namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels;
    using EventsSchedule.Web.ViewModels.Events;

    public class EventsService : IEventsService
    {
        private readonly ICategoryService categoryService;
        private readonly IDeletableEntityRepository<Event> eventsRepository;

        public EventsService(ICategoryService categoryService, IDeletableEntityRepository<Event> eventsRepository)
        {
            this.categoryService = categoryService;
            this.eventsRepository = eventsRepository;
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

        public T GetById<T>(string id)
        {
            var eventDetails = this.eventsRepository.AllAsNoTracking().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return eventDetails;
        }

        //public async Task<TopEventViewModel> DetailsTopEvent(Event @event)
        //{
        //    var detailsEvent = new TopEventViewModel
        //    {
        //        Description = @event.Description,
        //        DoorTime = @event.DoorTime,
        //        Duration = @event.Duration,
        //        EventCategory = @event.EventCategory,
        //        MaximumAttendeeCapacity = @event.MaximumAttendeeCapacity,
        //        Performer = @event.Performer,
        //        Price = @event.Price,
        //        Title = @event.Title,
        //    };

        //    return detailsEvent;
        //}

        //public Task<ListTopEvents> GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
