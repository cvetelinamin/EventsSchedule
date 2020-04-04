namespace EventsSchedule.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Models;b
    using EventsSchedule.Services.Data;
    using EventsSchedule.Services.Mapping;
    using EventsSchedule.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : Controller
    {
        private readonly IEventsService eventsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReviewsService reviewsService;
        private readonly ApplicationDbContext dbContext;

        public ReviewsController(IEventsService eventsService, UserManager<ApplicationUser> userManager, IReviewsService reviewsService, ApplicationDbContext dbContext)
        {
            this.eventsService = eventsService;
            this.userManager = userManager;
            this.reviewsService = reviewsService;
            this.dbContext = dbContext;
        }

        [Route("Reviews/Add/{eventId}")]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Reviews/Add/{eventId}")]
        public async Task<IActionResult> Add(ReviewCreateInputModel reviewCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(reviewCreateInputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.reviewsService.CreateAsync(reviewCreateInputModel.Comment, reviewCreateInputModel.Rating, user.Id, reviewCreateInputModel.EventId);

            return this.RedirectToAction("EventById", "Events", new { reviewCreateInputModel.EventId });
        }

        [Route("Reviews/ListAllReviews/{eventId}")]
        public async Task<IActionResult> ListAllReviews([FromRoute]string eventId)
        {
            var viewModel = new ListReviewsViewModel
            {
                Reviews = this.dbContext.Reviews
                          .Where(r => r.EventId == eventId)
                          .OrderByDescending(e => e.CreatedOn)
                          .To<EventReviewViewModel>()
                          .ToList(),
            };

            return this.View(viewModel);
        }
    }
}
