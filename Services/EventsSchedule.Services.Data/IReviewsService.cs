namespace EventsSchedule.Services.Data
{
    using System.Threading.Tasks;

    public interface IReviewsService
    {
        Task CreateAsync(string comment, int raiting, string userId, string eventId);
    }
}
