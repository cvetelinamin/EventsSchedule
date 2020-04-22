namespace EventsSchedule.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class AddressesService : IAddressesService
    {
        private readonly IDeletableEntityRepository<Address> addressesRepository;
        private readonly ICityService cityService;

        public AddressesService(IDeletableEntityRepository<Address> addressesRepository, ICityService cityService)
        {
            this.addressesRepository = addressesRepository;
            this.cityService = cityService;
        }

        public async Task<Address> CreateAddress(string cityId, string street, string additionalInformation)
        {
            var address = new Address
            {
                 CityId = cityId,
                 Street = street,
                 AdditionalInformation = additionalInformation,
            };

            return address;
        }

        public T GetById<T>(string id)
        {
            var address = this.addressesRepository.AllAsNoTracking().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return address;
        }
    }
}
