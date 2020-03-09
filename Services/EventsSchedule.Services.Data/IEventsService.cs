namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels.Events;

    public interface IEventsService
    {
        Event CreatEvent(EventInputModel model, string userId, Organizer organizer);
    }
}
