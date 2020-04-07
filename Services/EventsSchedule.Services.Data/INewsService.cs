namespace EventsSchedule.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INewsService
    {
        Task<string> CreateAsync(string title, string content, string userId);

        T GetById<T>(string id);

        int CountNews();

        IEnumerable<T> GetAll<T>(int? take = null, int skip = 0);
    }
}
