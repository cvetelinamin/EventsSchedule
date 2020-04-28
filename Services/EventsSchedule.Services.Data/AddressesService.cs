namespace EventsSchedule.Services.Data
{
    using System.Linq;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Mapping;

    public class AddressesService : IAddressesService
    {
        private readonly IDeletableEntityRepository<Address> addressesRepository;

        public AddressesService(IDeletableEntityRepository<Address> addressesRepository)
        {
            this.addressesRepository = addressesRepository;
        }

        public Address CreateAddress(string cityId, string street, string additionalInformation)
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
