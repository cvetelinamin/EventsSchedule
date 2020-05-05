namespace EventsSchedule.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Events;
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
        private readonly ICloudinaryService cloudinaryService;
        private readonly IDeletableEntityRepository<Event> eventRepository;

        public EventsController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IEventsService eventsService, IOrganizersService organizersService, IAddressesService addressesService, ICloudinaryService cloudinaryService, IDeletableEntityRepository<Event> eventRepository)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.eventsService = eventsService;
            this.organizersService = organizersService;
            this.addressesService = addressesService;
            this.cloudinaryService = cloudinaryService;
            this.eventRepository = eventRepository;
        }

        [Authorize]
        public IActionResult Create()
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

            string pictureUrl = this.cloudinaryService.UploadPicture(model.Image, model.Title);
            Organizer organizer = AutoMapperConfig.MapperInstance.Map<Organizer>(model);

            Address address = AutoMapperConfig.MapperInstance.Map<Address>(model);

            Event inputEvent = this.GetEventByInput(model, user, pictureUrl, organizer, address);

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

        public IActionResult EventsByCategory(string id)
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

        private Event GetEventByInput(CreateEventInputModel model, string user, string pictureUrl, Organizer organizer, Address address)
        {
            var eventMap = AutoMapperConfig.MapperInstance.Map<Event>(model);
            eventMap.Address = address;
            eventMap.CreatorId = user;
            eventMap.Image = pictureUrl;
            eventMap.Organizer = organizer;

            return eventMap;
        }
    }
}
