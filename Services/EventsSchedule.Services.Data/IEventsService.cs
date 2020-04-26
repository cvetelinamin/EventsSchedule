namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Data.Models.Enums;
    using EventsSchedule.Web.ViewModels.Events;

    public interface IEventsService
    {
        Task<Event> CreatEvent(string title, string performer, DateTime doorTime, DateTime endTime, string description, int maxCapacity, bool isFree, decimal price, EventStatusType status, TypicalAgeRange ageRange, string category, string userId, Organizer organizer, Address address, string pictureUrl);

        T GetById<T>(string id);

        IQueryable<Event> GetEventsByCategoryName(string name);

        IEnumerable<T> GetEvents<T>(string categoryId, EventsPriceSort priceSort, string cityId, TypicalAgeRange typicalAgeRange);

        IEnumerable<T> GetEventsPerPage<T>(IEnumerable<T> events, int? take = null, int skip = 0);

        Task EditEvent(EventsEditViewModel eventEditViewModel, Event eventToEdit);

        IEnumerable<T> GetTopEvents<T>();
    }
}
