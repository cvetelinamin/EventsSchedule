namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels.Reviews;

    public interface IReviewsService
    {
        Task CreateAsync(string comment, int raiting, string userId, string eventId);
    }
}
