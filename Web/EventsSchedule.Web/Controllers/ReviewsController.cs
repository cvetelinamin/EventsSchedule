namespace EventsSchedule.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using EventsSchedule.Data.Models;
    using EventsSchedule.Services.Data;
    using EventsSchedule.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : Controller
    {
        private const int ItemsPerPage = 3;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReviewsService reviewsService;

        public ReviewsController(UserManager<ApplicationUser> userManager, IReviewsService reviewsService)
        {
            this.userManager = userManager;
            this.reviewsService = reviewsService;
        }

        [Route("Reviews/Add")]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [Route("Reviews/Add")]
        public async Task<IActionResult> Add(ReviewCreateInputModel reviewCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(reviewCreateInputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.reviewsService.CreateAsync(reviewCreateInputModel.Comment, reviewCreateInputModel.Rating, user.Id, reviewCreateInputModel.EventId);

            var eventId = reviewCreateInputModel.EventId;

            return this.Redirect($"ListAllReviews/{eventId}/1");
        }

        [Route("Reviews/ListAllReviews/{eventId}/{page}")]
        public IActionResult ListAllReviews([FromRoute]string eventId, int page = 1)
        {
            var count = this.reviewsService.GetCountByEventId(eventId);

            var viewModel = new ListReviewsViewModel
            {
                EventReviews = this.reviewsService.GetEventReviews<EventReviewViewModel>(eventId, ItemsPerPage, (page - 1) * ItemsPerPage),
                PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage),
                CurrentPage = page,
                EventId = eventId,
            };

            return this.View(viewModel);
        }
    }
}
