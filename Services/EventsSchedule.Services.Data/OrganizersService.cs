namespace EventsSchedule.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

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

        public T GetById<T>(string id)
        {
            var organizer = this.organizerRepository.AllAsNoTracking().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return organizer;
        }
    }
}
