namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels.Addresses;
    using Microsoft.AspNetCore.Mvc;

    public class AddressesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Address> addressesRepository;
        private readonly IDeletableEntityRepository<Event> eventsRepository;
        private readonly IAddressesService addressesService;

        public AddressesController(IDeletableEntityRepository<Address> addressesRepository, IDeletableEntityRepository<Event> eventsRepository, IAddressesService addressesService)
        {
            this.addressesRepository = addressesRepository;
            this.eventsRepository = eventsRepository;
            this.addressesService = addressesService;
        }

        [HttpGet("/Administration/Addresses/EditAddress")]
        public IActionResult EditAddress(string eventId, string addressId)
        {
            var eventToChange = this.eventsRepository.AllAsNoTracking().Where(e => e.Id == eventId).FirstOrDefault();

            if (eventToChange.AddressId != addressId)
            {
                return this.NotFound();
            }

            var addressViewModel = this.addressesService.GetById<AddressEditModel>(addressId);

            if (addressViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(addressViewModel);
        }

        [HttpPost("/Administration/Addresses/EditAddress")]
        public async Task<IActionResult> EditAddress(AddressEditModel addressEditModel, string eventId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(addressEditModel);
            }

            var addressToChange = this.addressesRepository.AllWithDeleted().Where(n => n.Id == addressEditModel.Id).FirstOrDefault();

            addressToChange.AdditionalInformation = addressEditModel.AdditionalInformation;
            addressToChange.CityId = addressEditModel.CityId;
            addressToChange.ModifiedOn = DateTime.UtcNow;
            addressToChange.Street = addressEditModel.Street;

            this.addressesRepository.Update(addressToChange);
            await this.addressesRepository.SaveChangesAsync();

            return this.Redirect($"/Events/EventById?eventId={eventId}");
        }
    }
}
