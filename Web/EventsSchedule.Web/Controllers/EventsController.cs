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
    using EventsSchedule.Web.ViewModels.Events;
    using EventsSchedule.Web.ViewModels.Organizers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class EventsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEventsService eventsService;
        private readonly IOrganizersService organizersService;
        private readonly IAddressesService addressesService;
        private readonly ICityService cityService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly ICategoriesService categoryService;
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IDeletableEntityRepository<EventCategory> categoriesRepository;

        public EventsController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IEventsService eventsService, IOrganizersService organizersService, IAddressesService addressesService, ICityService cityService, ICloudinaryService cloudinaryService, ICategoriesService categoryService, IDeletableEntityRepository<Event> eventRepository, IDeletableEntityRepository<EventCategory> categoriesRepository)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.eventsService = eventsService;
            this.organizersService = organizersService;
            this.addressesService = addressesService;
            this.cityService = cityService;
            this.cloudinaryService = cloudinaryService;
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
        public async Task<IActionResult> Create(CreateEventModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = this.userManager.GetUserId(this.User);

            string pictureUrl = this.cloudinaryService.UploadPicture(model.Image, model.Title);

            var organizer = await this.organizersService.CreateOrganizer(model.Name, model.ContactName, model.WebSite, model.Description);

            var address = await this.addressesService.CreateAddress(model.CityId, model.Street, model.AdditionalInformation);

            var inputEvent = await this.eventsService.CreatEvent(model.Title, model.Performer, model.DoorTime, model.EndTime, model.Duration, model.Description, model.EventSchedule, model.MaximumAttendeeCapacity, model.IsAccessibleForFree, model.Price, model.Status, model.AgeRange, model.CategoryId, user, organizer, address, pictureUrl);

            await this.dbContext.Events.AddAsync(inputEvent);

            var eventuser = new UserEvent
            {
                ApplicationUserId = user,
                Event = inputEvent,
            };

            await this.dbContext.UsersEvents.AddAsync(eventuser);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("EventById", "Events", new { eventId = inputEvent.Id });
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

        public async Task<IActionResult> EventsByCategory(string id)
        {
            var viewModel = new ListEventsByCategory
            {
                Events = this.eventRepository.AllAsNoTracking()
                                .Where(e => e.EventCategory.Id == id)
                                .OrderByDescending(e => e.CreatedOn)
                                .To<EventShortViewModel>()
                .ToList(),
            };

            return this.View(viewModel);
        }
    }
}
