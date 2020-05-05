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
    using EventsSchedule.Web.ViewModels.Events;

    public class EventsService : IEventsService
    {
        private readonly ICategoriesService categoryService;
        private readonly IDeletableEntityRepository<Event> eventsRepository;
        private readonly ICloudinaryService cloudinaryService;

        public EventsService(ICategoriesService categoryService, IDeletableEntityRepository<Event> eventsRepository, ICloudinaryService cloudinaryService)
        {
            this.categoryService = categoryService;
            this.eventsRepository = eventsRepository;
            this.cloudinaryService = cloudinaryService;
        }

        public Event CreatEvent(string title, string performer, DateTime doorTime, DateTime endTime, string description, int maxCapacity, bool isFree, decimal price, EventStatusType status, TypicalAgeRange ageRange, string categoryId, string userId, Organizer organizer, Address address, string pictureUrl)
        {
            var eventToCreate = new Event
            {
                Title = title,
                Performer = performer,
                DoorTime = doorTime,
                EndTime = endTime,
                Description = description,
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

        public Event Create(Event eventInput, string userId, Organizer organizer, Address address, string pictureUrl)
        {
            eventInput.CreatorId = userId;
            eventInput.Organizer = organizer;
            eventInput.Address = address;
            eventInput.Image = pictureUrl;

            return eventInput;
        }

        public T GetById<T>(string id)
        {
            var eventDetails = this.eventsRepository.AllAsNoTracking().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return eventDetails;
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

        public IEnumerable<T> GetTopEvents<T>()
        {
            var events = this.eventsRepository.AllAsNoTracking().OrderByDescending(e => e.Reviews.Average(r => r.Rating)).Take(3);

            return events.To<T>().ToList();
        }

        public IQueryable GetAll()
        {
            return this.eventsRepository.AllAsNoTracking();
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

        public async Task EditEvent(EventsEditViewModel eventEditViewModel, Event eventToEdit)
        {
            string pictureUrl = this.cloudinaryService.UploadPicture(eventEditViewModel.Image, eventEditViewModel.Title);

            eventToEdit.DoorTime = eventEditViewModel.DoorTime;
            eventToEdit.EndTime = eventEditViewModel.EndTime;
            eventToEdit.EventCategoryId = eventEditViewModel.CategoryId;
            eventToEdit.Description = eventEditViewModel.Description;

            if (eventEditViewModel.Image != null)
            {
                eventToEdit.Image = pictureUrl;
            }

            eventToEdit.IsAccessibleForFree = eventEditViewModel.IsAccessibleForFree;
            eventToEdit.MaximumAttendeeCapacity = eventEditViewModel.MaximumAttendeeCapacity;
            eventToEdit.ModifiedOn = DateTime.UtcNow;
            eventToEdit.Performer = eventEditViewModel.Performer;
            eventToEdit.Price = eventEditViewModel.Price;
            eventToEdit.Status = eventEditViewModel.Status;
            eventToEdit.Title = eventEditViewModel.Title;

            this.eventsRepository.Update(eventToEdit);
            await this.eventsRepository.SaveChangesAsync();
        }

        public IQueryable<Event> GetEventsByCategoryName(string name)
        {
            return this.eventsRepository.AllAsNoTracking()
                                        .Where(e => e.EventCategory.Name == name)
                                        .OrderByDescending(e => e.CreatedOn);
        }

        private IQueryable<Event> SortEventsByPrice(IQueryable<Event> events, EventsPriceSort sort)
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

        private IQueryable<Event> FilterEventsByCity(IQueryable<Event> events, string cityId)
        {
            return events.Where(e => e.Address.CityId == cityId);
        }

        private IQueryable<Event> FilterEventsByAudienceAge(IQueryable<Event> events, TypicalAgeRange typicalAgeRange)
        {
            return events.Where(e => e.AgeRange == typicalAgeRange);
        }
    }
}
