namespace EventsSchedule.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels;
    using EventsSchedule.Web.ViewModels.Categories;
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
        private readonly ICategoriesService categoryService;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IDeletableEntityRepository<EventCategory> categoriesRepository;

        public EventsController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IEventsService eventsService, IOrganizersService organizersService, IAddressesService addressesService, ICityService cityService, ICategoriesService categoryService, IDeletableEntityRepository<Event> eventRepository, IDeletableEntityRepository<EventCategory> categoriesRepository)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.eventsService = eventsService;
            this.organizersService = organizersService;
            this.addressesService = addressesService;
            this.cityService = cityService;
            this.categoryService = categoryService;
            this.eventRepository = eventRepository;
            this.categoriesRepository = categoriesRepository;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateEventInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = this.userManager.GetUserId(this.User);
            var organizerInputModel = model.OrganizerInputModel;
            var addressInputModel = model.AdressInputModel;
            var eventInputModel = model.EventInputModel;

            var organizer = await this.organizersService.CreateOrganizer(organizerInputModel.Name, organizerInputModel.ContactName, organizerInputModel.WebSite, organizerInputModel.Description);

            var address = await this.addressesService.CreateAddress(addressInputModel.CityId, addressInputModel.Street, addressInputModel.AdditionalInformation);

            var inputEvent = await this.eventsService.CreatEvent(eventInputModel.Title, eventInputModel.Performer, eventInputModel.DoorTime, eventInputModel.EndTime, eventInputModel.Duration, eventInputModel.Description, eventInputModel.EventSchedule, eventInputModel.MaximumAttendeeCapacity, eventInputModel.IsAccessibleForFree, eventInputModel.Price, eventInputModel.Status, eventInputModel.AgeRange, eventInputModel.CategoryId, user, organizer, address);

            await this.dbContext.Events.AddAsync(inputEvent);

            var eventuser = new UserEvent
            {
                ApplicationUserId = user,
                Event = inputEvent,
            };

            await this.dbContext.UsersEvents.AddAsync(eventuser);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("EventById", "Events", new { id = inputEvent.Id });
        }

        public IActionResult EventById(string eventId)
        {
            var eventViewModel = this.eventsService.GetById<EventViewModel>(eventId);
            if (eventViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(eventViewModel);
        }

        [Authorize]
        public async Task<IActionResult> EventsByCategory(string name)
        {
            var viewModel = new ListEventsByCategory
            {
                Events = this.eventRepository.AllAsNoTracking()
                                .Where(e => e.EventCategory.Name == name)
                                .OrderByDescending(e => e.CreatedOn)
                                .To<EventShortViewModel>()
                .ToList(),
            };

            return this.View(viewModel);
        }
    }
}
