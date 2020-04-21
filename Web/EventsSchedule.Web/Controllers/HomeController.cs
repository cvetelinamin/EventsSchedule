namespace EventsSchedule.Web.Controllers
{
    using System;
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
        private const int ItemsPerPage = 2;

        private readonly ApplicationDbContext dbContext;
        private readonly ICategoriesService categoriesService;
        private readonly IEventsService eventsService;
        private readonly IDeletableEntityRepository<Event> eventsRepository;

        public HomeController(ApplicationDbContext dbContext, ICategoriesService categoriesService, IEventsService eventsService, IDeletableEntityRepository<Event> eventsRepository)
        {
            this.dbContext = dbContext;
            this.categoriesService = categoriesService;
            this.eventsService = eventsService;
            this.eventsRepository = eventsRepository;
        }

        public async Task<IActionResult> Index(IndexInputModel model, int page = 1)
        {
            var categories = this.categoriesService.GetAll();
            var events = this.eventsService.GetEvents<EventShortViewModel>(model.EventCategoryId, model.PriceSort, model.CityId, model.TypicalAgeRangeSort);

            var count = events.Count();

            var eventsPerPage = this.eventsService.GetEventsPerPage<EventShortViewModel>(events, ItemsPerPage, (page - 1) * ItemsPerPage);

            var viewModel = new IndexViewModel
            {
                EventCategoryId = model.EventCategoryId,
                PriceSort = model.PriceSort,
                Categories = categories,
                Events = eventsPerPage,
                CityId = model.CityId,
                TypicalAgeRangeSort = model.TypicalAgeRangeSort,
                CurrentPage = page,
                PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage),
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
