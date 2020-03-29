namespace EventsSchedule.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Data.Models.Enums;

    public interface IEventsService
    {
        Task<Event> CreatEvent(string title, string performer, DateTime doorTime, DateTime endTime, int duration, string description, string schedule, int maxCapacity, bool isFree, decimal price, EventStatusType status, TypicalAgeRange ageRange, EventCategory category, string userId, Organizer organizer, Address address);

        T GetById<T>(string id);
        //Task<TopEventViewModel> DetailsTopEvent();

        //Task<ListTopEvents> GetAll();
    }
}
