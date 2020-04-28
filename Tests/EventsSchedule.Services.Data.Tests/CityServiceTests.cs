namespace EventsSchedule.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CityServiceTests
    {
        [Fact]
        public async Task CitiesCreateAllWithCorrectData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<City>(new ApplicationDbContext(options.Options));

            var service = new CityService(repository);
            await service.CreateAllAsync(new[] { "Варна", "София", "Пловдив" });

            var citiesCount = repository.AllAsNoTracking().Count();

            Assert.Equal(3, citiesCount);
        }

        [Fact]
        public async Task GetAllCitiesTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<City>(new ApplicationDbContext(options.Options));

            var service = new CityService(repository);
            await service.CreateAllAsync(new[] { "Варна", "София", "Пловдив" });

            var citiesTitles = await service.GetAllCitiesAsync();
            var citiesCount = citiesTitles.Count();

            Assert.Equal(3, citiesCount);
        }

        [Fact]
        public async Task GetIdWithTitleTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<City>(new ApplicationDbContext(options.Options));
            var service = new CityService(repository);
            await service.CreateAllAsync(new[] { "Варна", "София", "Пловдив" });

            var cityId = await service.GetIdByTitleAsync("Варна");
            Assert.NotNull(cityId);
        }
    }
}
