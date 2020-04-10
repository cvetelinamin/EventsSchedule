﻿namespace EventsSchedule.Services.Data
{
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;

    public class AddressesService : IAddressesService
    {
        private readonly IDeletableEntityRepository<Address> addressesRepository;
        private readonly ICityService cityService;

        public AddressesService(IDeletableEntityRepository<Address> addressesRepository, ICityService cityService)
        {
            this.addressesRepository = addressesRepository;
            this.cityService = cityService;
        }

        public async Task<Address> CreateAddress(City city, string street, string additionalInformation)
        {
            var address = new Address
            {
                 CityId = await this.cityService.GetIdByTitleAsync(city.Name),
                 Street = street,
                 AdditionalInformation = additionalInformation,
            };

            return address;
        }
    }
}
