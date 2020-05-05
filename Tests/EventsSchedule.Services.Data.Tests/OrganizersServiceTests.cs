namespace EventsSchedule.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Data.Repositories;
    using EventsSchedule.Web.ViewModels.Organizers;
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

            var organizerToCreate = new OrganizerCreateModel
            {
                Name = "Монте Мюзик",
                ContactName = "Графа",
                WebSite = "www.montemusic.bg",
                OrganizerDescription = "asdasdasdadasd",
            };

        //    var organizer = service.Create(organizerToCreate);

         //   await repository.AddAsync(organizer);

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

            var organizerToCreate = new OrganizerCreateModel
            {
                Name = "Монте Мюзик",
                ContactName = "Графа",
                WebSite = "www.montemusic.bg",
                OrganizerDescription = "asdasdasdadasd",
            };

           // var organizer = service.Create(organizerToCreate);

         //   await repository.AddAsync(organizer);

           // var id = service.GetById<Organizer>(organizer.Id);

         //   Assert.NotNull(id);
        }
    }
}
