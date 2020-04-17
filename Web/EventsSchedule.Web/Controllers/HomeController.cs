namespace EventsSchedule.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels;
    using EventsSchedule.Web.ViewModels.Events;
    using EventsSchedule.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICategoriesService categoriesService;
        private readonly IDeletableEntityRepository<Event> eventsRepository;

        public HomeController(ApplicationDbContext dbContext, ICategoriesService categoriesService, IDeletableEntityRepository<Event> eventsRepository)
        {
            this.dbContext = dbContext;
            this.categoriesService = categoriesService;
            this.eventsRepository = eventsRepository;
        }

        public async Task<IActionResult> Index(IndexInputModel model)
        {
            var categories = this.categoriesService.GetAll();

            var viewModel = new IndexViewModel
            {
                Categories = categories,
                Events = this.eventsRepository.AllAsNoTracking()
                                .Where(e => e.EventCategory.Id == model.EventCategotyId)
                                .OrderByDescending(e => e.CreatedOn)
                                .To<EventShortViewModel>()
                .ToList(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Team()
        {
            return this.View();
        }

        public IActionResult Contacts()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
