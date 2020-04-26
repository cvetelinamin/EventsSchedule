namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.News;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class NewsController : AdministrationController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly INewsService newsService;
        private readonly IDeletableEntityRepository<News> newsRepository;
        private readonly ICloudinaryService cloudinaryService;

        public NewsController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, INewsService newsService, IDeletableEntityRepository<News> newsRepository, ICloudinaryService cloudinaryService)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.newsService = newsService;
            this.newsRepository = newsRepository;
            this.cloudinaryService = cloudinaryService;
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

            string pictureUrl = this.cloudinaryService.UploadPicture(model.Image, model.Title);

            var newsId = await this.newsService.CreateAsync(model.Title, model.Content, pictureUrl, user.Id);

            return this.RedirectToAction("NewsDetails", "News", new { newsId, Area = "User" });
        }

        [HttpGet("/Administration/News/Edit")]
        public async Task<IActionResult> Edit(string newsId)
        {
            var newsViewModel = this.dbContext.News.To<NewsEditViewModel>().FirstOrDefault(n => n.Id == newsId);

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

            string pictureUrl = this.cloudinaryService.UploadPicture(newsEditViewModel.Image, newsEditViewModel.Title);

            if (newsEditViewModel.Image != null)
            {
                newsToEdit.Image = pictureUrl;
            }

            this.newsRepository.Update(newsToEdit);
            await this.newsRepository.SaveChangesAsync();

            var newsId = newsToEdit.Id;

            return this.RedirectToAction("NewsDetails", "News", new { newsId, Area = "User" });
        }

        public async Task<IActionResult> Delete(string newsId)
        {
            var news = this.newsRepository.All().FirstOrDefault(x => x.Id == newsId);
            this.newsRepository.Delete(news);
            await this.newsRepository.SaveChangesAsync();

            return this.RedirectToAction("GetAll", "News", new { Area = "User" });
        }
    }
}
