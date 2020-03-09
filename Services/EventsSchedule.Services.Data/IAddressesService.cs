namespace EventsSchedule.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Web.ViewModels.Addresses;
    using EventsSchedule.Web.ViewModels.Events;

    public interface IAddressesService
    {
        Address CreateAddress(AddressInputModel model, City city, Organizer organizer);
    }
}
