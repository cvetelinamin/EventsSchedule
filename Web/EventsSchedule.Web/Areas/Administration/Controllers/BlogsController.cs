namespace EventsSchedule.Web.Areas.Administration.Controllers
{
    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels.Blogs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize(Roles = "Administrator")]
    public class BlogsController : AdministrationController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlogsService blogsService;

        public BlogsController(UserManager<ApplicationUser> userManager, IBlogsService blogsService)
        {
            this.userManager = userManager;
            this.blogsService = blogsService;
        }

        [HttpGet("/Administration/Blogs/Create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost("/Administration/Blogs/Create")]
        public async Task<IActionResult> Create(BlogInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            var blogId = await this.blogsService.CreateAsync(model.Title, model.Content, user.Id);

            return this.RedirectToAction( "BlogView", "Blogs", new { blogId });
        }
    }
}
