namespace EventsSchedule.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICityService
    {
        Task CreateAllAsync(string[] cityNames);

        Task<IEnumerable<string>> GetAllCitiesAsync();

        Task<string> GetIdByTitleAsync(string cityName);
    }
}
