namespace EventsSchedule.Services.Data
{
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using System.Threading.Tasks;

    public class OrganizersService : IOrganizersService
    {
        private readonly IDeletableEntityRepository<Organizer> organizerRepository;

        public OrganizersService(IDeletableEntityRepository<Organizer> organizerRepository)
        {
            this.organizerRepository = organizerRepository;
        }

        public async Task<Organizer> CreateOrganizer(string name, string contactName, string webSite, string description)
        {
            var organizer = new Organizer
            {
                 Name = name,
                 ContactName = contactName,
                 WebSite = webSite,
                 Description = description,
            };

            return organizer;
        }
    }
}
