namespace EventsSchedule.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;

    public interface ICategoriesService
    {
        Task CreateAllAsync(string[] titles);

        Task<IEnumerable<string>> GetAllTitlesAsync();

        Task<EventCategory> CreateAsync(string name);

        ICollection<EventCategory> GetAll();

        Task<string> GetIdByTitleAsync(string categoryTitle);
    }
}
