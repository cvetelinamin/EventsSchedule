namespace EventsSchedule.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using EventsSchedule.Data;
    using EventsSchedule.Data.Common.Repositories;
    using EventsSchedule.Data.Models;
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
        private readonly IDeletableEntityRepository<Event> eventRepository;
        private readonly IDeletableEntityRepository<Review> reviewRepository;
        private readonly ApplicationDbContext dbContext;

        public ReviewsController(IEventsService eventsService, UserManager<ApplicationUser> userManager, IReviewsService reviewsService, IDeletableEntityRepository<Event> eventRepository, IDeletableEntityRepository<Review> reviewRepository, ApplicationDbContext dbContext)
        {
            this.eventsService = eventsService;
            this.userManager = userManager;
            this.reviewsService = reviewsService;
            this.eventRepository = eventRepository;
            this.reviewRepository = reviewRepository;
            this.dbContext = dbContext;
        }

        [Route("Reviews/Add/{eventId}")]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Reviews/Add/{eventId}")]
        public async Task<IActionResult> Add(ReviewCreateInputModel reviewCreateInputModel, [FromRoute] string eventId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(reviewCreateInputModel);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.reviewsService.CreateAsync(reviewCreateInputModel.Comment, reviewCreateInputModel.Rating, user.Id, eventId);

            return this.RedirectToAction("ListReviews", "Reviews", new { eventId });
        }

        public async Task<IActionResult> ListLastReviews()
        {
            var viewModel = new ListReviewsViewModel
            {
                Reviews = this.reviewRepository.AllAsNoTracking()
                    .OrderByDescending(e => e.CreatedOn)
                    .Take(3)
                    .To<ReviewViewModel>()
                    .ToList(),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> ListAllReviews()
        {
            var viewModel = new ListReviewsViewModel
            {
                Reviews = this.reviewRepository.AllAsNoTracking()
                          .OrderByDescending(e => e.CreatedOn)
                          .To<ReviewViewModel>()
                          .ToList(),
            };

            return this.View(viewModel);
        }
    }
}
