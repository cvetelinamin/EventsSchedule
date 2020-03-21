namespace EventsSchedule.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels;
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
        private readonly ICategoryService categoryService;
        private readonly IDeletableEntityRepository<Event> eventRepository;

        public EventsController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IEventsService eventsService, IOrganizersService organizersService, IAddressesService addressesService, ICityService cityService, ICategoryService categoryService, IDeletableEntityRepository<Event> eventRepository)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.eventsService = eventsService;
            this.organizersService = organizersService;
            this.addressesService = addressesService;
            this.cityService = cityService;
            this.categoryService = categoryService;
            this.eventRepository = eventRepository;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateEventModel model)
        {
            var user = this.userManager.GetUserId(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var organizer = this.organizersService.CreateOrganizer(model);
            var city = this.cityService.CreateCity(model.City);
            var address = this.addressesService.CreateAddress(model, city, organizer);
            var inputEvent = await this.eventsService.CreatEvent(model, user, organizer, address);

            await this.dbContext.Cities.AddAsync(city);
            await this.dbContext.Addresses.AddAsync(address);
            await this.dbContext.Organizers.AddAsync(organizer);
            await this.dbContext.Events.AddAsync(inputEvent);

            //var eventUser = new UserEvent
            //{
            //    ApplicationUserId = user,
            //    Event = inputEvent,
            //};

            //await this.dbContext.UsersEvents.AddAsync(eventUser);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("EventById", "Events", new { id = inputEvent.Id });
        }

        public IActionResult EventById(string id)
        {
            var eventViewModel = this.eventsService.GetById<EventViewModel>(id);
            if (eventViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(eventViewModel);
        }
    }
}
