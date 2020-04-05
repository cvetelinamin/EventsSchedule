namespace EventsSchedule.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReviewsService
    {
        Task CreateAsync(string comment, int raiting, string userId, string eventId);

        IEnumerable<T> GetEventReviews<T>(string eventId, int? take = null, int skip = 0);

        int GetCountByEventId(string eventId);
    }
}
