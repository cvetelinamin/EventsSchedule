namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
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

        public async Task<Event> CreatEvent(string title, string performer, DateTime doorTime, DateTime endTime, int duration, string description, string schedule, int maxCapacity, bool isFree, decimal price, EventStatusType status, TypicalAgeRange ageRange, string categoryId, string userId, Organizer organizer, Address address, string pictureUrl)
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
                Image = pictureUrl,
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

        public IQueryable<Event> SortEventsByPrice(IQueryable<Event> events, EventsPriceSort sort)
        {
            if (sort == EventsPriceSort.PriceDescending)
            {
                return events.OrderByDescending(e => e.Price);
            }
            else if (sort == EventsPriceSort.PriceAscending)
            {
                return events.OrderBy(e => e.Price);
            }

            return events.OrderByDescending(e => e.CreatedOn);
        }

        public IQueryable<Event> FilterEventsByCity(IQueryable<Event> events, string cityId)
        {
            return events.Where(e => e.Address.CityId == cityId);
        }

        public IQueryable<Event> FilterEventsByAudienceAge(IQueryable<Event> events, TypicalAgeRange typicalAgeRange)
        {
            return events.Where(e => e.AgeRange == typicalAgeRange);
        }

        public IEnumerable<T> GetEvents<T>(string categoryId, EventsPriceSort priceSort, string cityId, TypicalAgeRange typicalAgeRange)
        {
            var events = this.eventsRepository.AllAsNoTracking()
                                .Where(e => e.EventCategory.Id == categoryId);

            var sortedEvents = this.SortEventsByPrice(events, priceSort);

            if (cityId != null)
            {
                sortedEvents = this.FilterEventsByCity(sortedEvents, cityId);
            }

            if (typicalAgeRange != 0)
            {
                sortedEvents = this.FilterEventsByAudienceAge(sortedEvents, typicalAgeRange);
            }

            return sortedEvents.To<T>().ToList();
        }

        public IEnumerable<T> GetEventsPerPage<T>(IEnumerable<T> events, int? take = null, int skip = 0)
        {
            var query = events.Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }
    }
}
