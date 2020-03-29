namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CityService : ICityService
    {
        private const string InvalidCityNameErrorMessage = "City with Name: {0} does not exist.";

        private readonly IDeletableEntityRepository<City> cityRepository;

        public CityService(IDeletableEntityRepository<City> cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public async Task<IEnumerable<string>> GetAllCitiesAsync()
        {
            return await this.cityRepository
                .AllAsNoTracking()
                .Select(x => x.Name)
                .ToListAsync();
        }

        public async Task<string> GetIdByTitleAsync(string cityName)
        {
            var city = await this.cityRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == cityName);

            if (city == null)
            {
                throw new ArgumentNullException(
                    string.Format(InvalidCityNameErrorMessage, cityName));
            }

            return city.Id;
        }
    }
}
