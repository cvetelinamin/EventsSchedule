namespace EventsSchedule.Services.Data
{
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;

    public interface IBlogsService
    {
        Task<string> CreateAsync(string title, string content, string userId);
    }
}
