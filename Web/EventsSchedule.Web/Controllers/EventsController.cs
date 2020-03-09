namespace EventsSchedule.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels.Events;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEventsService eventsService;
        private readonly IOrganizersService organizersService;
        private readonly IAddressesService addressesService;
        private readonly ICityService cityService;

        public EventsController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IEventsService eventsService, IOrganizersService organizersService, IAddressesService addressesService, ICityService cityService)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.eventsService = eventsService;
            this.organizersService = organizersService;
            this.addressesService = addressesService;
            this.cityService = cityService;
        }

        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventInputModel model)
        {
            var user = this.userManager.GetUserId(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var organizer = this.organizersService.CreateOrganizer(model.OrganizerInputModel);
            var city = this.cityService.CreateCity(model.AdressInputModel.City);
            var address = this.addressesService.CreateAddress(model.AdressInputModel, city, organizer);
            var inputEvent = this.eventsService.CreatEvent(model.EventInputModel, user, organizer);

            await this.dbContext.Cities.AddAsync(city);
            await this.dbContext.Addresses.AddAsync(address);
            await this.dbContext.Organizers.AddAsync(organizer);
            await this.dbContext.Events.AddAsync(inputEvent);

            var eventUser = new UserEvent
            {
                ApplicationUserId = user,
                Event = inputEvent,
            };

            await this.dbContext.UsersEvents.AddAsync(eventUser);
            await this.dbContext.SaveChangesAsync();

            return this.View();
        }
    }
}
