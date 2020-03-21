namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels;
    using EventsSchedule.Web.ViewModels.Events;

    public interface IEventsService
    {
        Task<Event> CreatEvent(CreateEventModel model, string userId, Organizer organizer, Address address);

        T GetById<T>(string id);

        //Task<TopEventViewModel> DetailsTopEvent();

        //Task<ListTopEvents> GetAll();
    }
}
