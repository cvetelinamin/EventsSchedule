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

    public class CategoriesServiceTests
    {
        [Fact]
        public async Task CategoriesCreateAllWithCorrectData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<EventCategory>(new ApplicationDbContext(options.Options));
            var service = new CategoriesService(repository);
            await service.CreateAllAsync(new[] { "Концерти", "Театър", "Спорт" });

            var categoriesCount = repository.AllAsNoTracking().Count();

            Assert.Equal(3, categoriesCount);
        }

        [Fact]
        public async Task CategoriesCreateWithCorrectData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<EventCategory>(new ApplicationDbContext(options.Options));
            var service = new CategoriesService(repository);
            await service.CreateAsync("Концерти");

            var categoriesCount = repository.AllAsNoTracking().Count();

            Assert.Equal(1, categoriesCount);
        }

        [Fact]
        public async Task GetAllCategoriesTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<EventCategory>(new ApplicationDbContext(options.Options));
            var service = new CategoriesService(repository);

            await service.CreateAllAsync(new[] { "Концерти", "Театър", "Спорт" });

            var categories = service.GetAll();
            var categoriesCount = categories.Count();

            Assert.Equal(3, categoriesCount);
        }

        [Fact]
        public async Task GetAllCategoriesTitlesTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<EventCategory>(new ApplicationDbContext(options.Options));
            var service = new CategoriesService(repository);

            await service.CreateAllAsync(new[] { "Концерти", "Театър", "Спорт" });

            var categoriesTitles = await service.GetAllTitlesAsync();
            var categoriesCount = categoriesTitles.Count();

            Assert.Equal(3, categoriesCount);
        }

        [Fact]
        public async Task GetIdWithTitleTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<EventCategory>(new ApplicationDbContext(options.Options));
            var service = new CategoriesService(repository);

            await service.CreateAllAsync(new[] { "Концерти", "Театър", "Спорт" });

            var categoryId = await service.GetIdByTitleAsync("Концерти");
            Assert.NotNull(categoryId);
        }
    }
}
