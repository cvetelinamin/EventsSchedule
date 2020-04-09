namespace EventsSchedule.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels.News;
    using Microsoft.AspNetCore.Mvc;

    public class NewsController : Controller
    {
        private const int ItemsPerPage = 5;

        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public async Task<IActionResult> NewsDetails(string newsId)
        {
            var viewModel = this.newsService.GetById<NewsViewModel>(newsId);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public async Task<IActionResult> GetAll(int page = 1)
        {
            var count = this.newsService.CountNews();

            var viewModel = new GetAllNews
            {
                News = this.newsService.GetAll<NewsShortViewModel>(ItemsPerPage, (page - 1) * ItemsPerPage),
                PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage),
                CurrentPage = page,
            };

            return this.View(viewModel);
        }
    }
}
