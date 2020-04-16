namespace EventsSchedule.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Data.Models.Enums;
    using EventsSchedule.Services.Mapping;

    public class EventsService : IEventsService
    {
        private readonly ICategoriesService categoryService;
        private readonly IDeletableEntityRepository<Event> eventsRepository;

        public EventsService(ICategoriesService categoryService, IDeletableEntityRepository<Event> eventsRepository)
        {
            this.categoryService = categoryService;
            this.eventsRepository = eventsRepository;
        }

        public async Task<Event> CreatEvent(string title, string performer, DateTime doorTime, DateTime endTime, int duration, string description, string schedule, int maxCapacity, bool isFree, decimal price, EventStatusType status, TypicalAgeRange ageRange, string categoryId, string userId, Organizer organizer, Address address)
        {
            var eventToCreate = new Event
            {
                Title = title,
                Performer = performer,
                DoorTime = doorTime,
                EndTime = endTime,
                Duration = duration,
                Description = description,
                EventSchedule = schedule,
                MaximumAttendeeCapacity = maxCapacity,
                IsAccessibleForFree = isFree,
                Price = price,
                CreatorId = userId,
                Organizer = organizer,
                Status = status,
                AgeRange = ageRange,
                Address = address,
                EventCategoryId = categoryId,
            };

            return eventToCreate;
        }

        public T GetById<T>(string id)
        {
            var eventDetails = this.eventsRepository.AllAsNoTracking().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return eventDetails;
        }

        public IQueryable<Event> GetEventsByCategoryName(string name)
        {
            return this.eventsRepository.AllAsNoTracking()
                                        .Where(e => e.EventCategory.Name == name)
                                        .OrderByDescending(e => e.CreatedOn);
        }
    }
}
