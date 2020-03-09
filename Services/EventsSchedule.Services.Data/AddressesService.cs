namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels.Addresses;
    using EventsSchedule.Web.ViewModels.Events;

    public class AddressesService : IAddressesService
    {
        private readonly ICityService cityService;

        public Address CreateAddress(AddressInputModel model, City city, Organizer organizer)
        {
            var adress = new Address
            {
                City = city,
                Street = model.Street,
                Building = model.Building,
                Number = model.Number,
                Entrance = model.Entrance,
                Floor = model.Floor,
                Apartment = model.Apartment,
                District = model.District,
                Organizer = organizer,
            };

            return adress;
        }
    }
}
