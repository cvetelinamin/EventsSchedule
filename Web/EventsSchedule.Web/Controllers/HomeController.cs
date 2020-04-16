namespace EventsSchedule.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using EventsSchedule.Data;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels;
    using EventsSchedule.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICategoriesService categoriesService;

        public HomeController(ApplicationDbContext dbContext, ICategoriesService categoriesService)
        {
            this.dbContext = dbContext;
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await this.categoriesService.GetAllTitlesAsync();

            var viewModel = new IndexViewModel
            {
                Categories = categories,
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
