namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using EventsSchedule.Data;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels.News;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class NewsController : AdministrationController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INewsService newsService;
        private readonly IDeletableEntityRepository<Blog> newsRepository;

        public NewsController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, INewsService newsService, IDeletableEntityRepository<Blog> newsRepository)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.newsService = newsService;
            this.newsRepository = newsRepository;
        }

        [HttpGet("/Administration/News/Create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost("/Administration/News/Create")]
        public async Task<IActionResult> Create(NewsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            var newsId = await this.newsService.CreateAsync(model.Title, model.Content, user.Id);

            return this.RedirectToAction( "NewsDetails", "News", new { newsId, Area = "User"});
        }

        [HttpGet("/Administration/News/Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            var newsViewModel = this.newsService.GetById<NewsEditViewModel>(id);

            if (newsViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(newsViewModel);
        }

        [HttpPost("/Administration/News/Edit")]
        public async Task<IActionResult> Edit(NewsEditViewModel newsEditViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(newsEditViewModel);
            }

            var newsToEdit = this.newsRepository.AllWithDeleted().Where(n => n.Id == newsEditViewModel.Id).FirstOrDefault();

            newsToEdit.Title = newsEditViewModel.Title;
            newsToEdit.Content = newsEditViewModel.Content;
            newsToEdit.ModifiedOn = DateTime.UtcNow;

            this.newsRepository.Update(newsToEdit);
            await this.newsRepository.SaveChangesAsync();

            return this.RedirectToAction("NewsDetails", "News", new { newsToEdit.Id });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var news = this.newsRepository.All().FirstOrDefault(x => x.Id == id);
            this.newsRepository.Delete(news);
            await this.newsRepository.SaveChangesAsync();

            return this.RedirectToAction("AllNews", "News");
        }
    }
}
