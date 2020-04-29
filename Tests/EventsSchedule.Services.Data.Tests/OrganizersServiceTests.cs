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

    public class OrganizersServiceTests
    {
        [Fact]
        public async Task OrganizerCreateWithCorrectData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Organizer>(new ApplicationDbContext(options.Options));
            var service = new OrganizersService(repository);

            var organizer = service.CreateOrganizer("Монте Мюзик", "Графа", "www.montemusic.bg", "asdasdasdadasd");

            await repository.AddAsync(organizer);

            var organizerResult = repository.AllAsNoTracking().AsEnumerable().Count();

            Assert.Equal(1, organizerResult);
        }

        [Fact]
        public async Task GetOrganizerById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                             .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfDeletableEntityRepository<Organizer>(new ApplicationDbContext(options.Options));
            var service = new OrganizersService(repository);
            var organizer = service.CreateOrganizer("Монте Мюзик", "Графа", "www.montemusic.bg", "asdasdasdadasd");

            await repository.AddAsync(organizer);

            var id = service.GetById<Organizer>(organizer.Id);

            Assert.NotNull(id);
        }
    }
}
